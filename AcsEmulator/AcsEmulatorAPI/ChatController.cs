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

				await t.AddParticipants(db, participants);

				await db.ChatThreads.AddAsync(t);
				await db.SaveChangesAsync();

				var result = new
				{
					ChatThread = new
					{
						t.Id,
						t.Topic,
						t.CreatedOn,
						CreatedByCommunicationIdentifier = new
						{
							user.RawId
						}
					}
				};

				return Results.Created($"/chat/threads/{t.Id}", result);
			});

			app.MapGet("/chat/threads", [Authorize] async (ClaimsPrincipal principal, AcsDbContext db) =>
			{
				string userRawId = principal.Claims.First(x => x.Type == "skypeid").Value;

				var threads = await db.ChatThreads
					.Include(t => t.Participants.Where(p => p.RawId == userRawId))
					.Select(t => new { t.Id, t.Topic })
					.ToListAsync();

				return Results.Ok(new
				{
					value = threads
				});
			});
		}
	}
}
