using AcsEmulatorAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AcsEmulatorAPI
{
	// https://github.com/Azure/azure-rest-api-specs/blob/main/specification/communication/data-plane/Chat/stable/2021-09-07/communicationserviceschat.json
	public static class ChatController
	{
		public static void AddChatEndpoints(this WebApplication app)
		{
			app.MapPost("/chat/threads", [Authorize] async (ClaimsPrincipal principal, AcsDbContext db, CreateChatThreadRequest req) =>
			{
				string userRawId = principal.Claims.First(x => x.Type == "skypeid").Value;

				var user = await db.Users.FindAsync(userRawId);

				if (user == null)
				{
					return Results.Forbid();
				}

				var t = ChatThread.CreateNew(req.Topic, user);

				var participants = req.Participants ?? new List<ChatParticipant>();

				// the chat thread creator always gets added as a participant
				if (!participants.Any(x => x.CommunicationIdentifier.RawId == userRawId))
				{
					// todo: handle displayName and shareHistoryTime defaults - just null or default values in db?
					participants.Add(new ChatParticipant(new CommunicationIdentifier(userRawId), null, null));
				}

				await t.AddParticipants(db, user, participants);

				await db.ChatThreads.AddAsync(t);
				await db.SaveChangesAsync();

				var result = new
				{
					ChatThread = new
					{
						t.Id,
						t.Topic,
						t.CreatedOn,
						CreatedByCommunicationIdentifier = new CommunicationIdentifier(user.RawId)
					}
				};

				return Results.Created($"/chat/threads/{t.Id}", result);
			});

			app.MapGet("/chat/threads", [Authorize] async (ClaimsPrincipal principal, AcsDbContext db) =>
			{
				string userRawId = principal.Claims.First(x => x.Type == "skypeid").Value;

				var threads = await db.ChatThreads
					.Include(t => t.Participants)
					.Where(t => t.Participants.Any(p => p.RawId == userRawId))
					.Select(t => new { t.Id, t.Topic })
					.ToListAsync();

				return Results.Ok(new
				{
					value = threads
				});
			});

			app.MapGet("/chat/threads/{chatThreadId}", [Authorize] async (ClaimsPrincipal principal, AcsDbContext db, string chatThreadId) =>
			{
				string userRawId = principal.Claims.First(x => x.Type == "skypeid").Value;

				var thread = await db.ChatThreads.FindAsync(chatThreadId);

				if (thread == null)
				{
					return Results.NotFound();
				}

				if (!thread.Participants.Any(p => p.RawId == userRawId))
				{
					return Results.Forbid();
				}

				return Results.Ok(new
				{
					thread.Id,
					thread.Topic,
					thread.CreatedOn,
					createdByCommunicationIdentifier = new CommunicationIdentifier(thread.CreatedBy.RawId)
				});
			});

			// "Admin" API for the Emulator UI to be able to display all threads in the system, no matter which user created them.
			// Real ACS backend doesn't have this API.
			app.MapGet("/admin/chat/threads", async (AcsDbContext db) =>
			{
				var threads = await db.ChatThreads
					.Select(t => new
						{
							t.Id,
							t.Topic,
							t.CreatedOn,
							CreatedBy = new
							{
								Kind = "communicationUser",
								CommunicationUserId = t.CreatedBy.RawId
							}
						})
					.ToListAsync();

				return Results.Ok(new
				{
					value = threads,
				});
			});
		}
	}
}
