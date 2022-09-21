using AcsEmulatorAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AcsEmulatorAPI
{
	// https://github.com/Azure/azure-rest-api-specs/blob/main/specification/communication/data-plane/Chat/stable/2021-09-07/communicationserviceschat.json
	public static class Chat
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

				// For now return threads created by user
				// TODO: return all threads where user is a participant 
				var threads = await db.ChatThreads
					.Where(t => t.CreatedBy.RawId == userRawId)
					.Select(t => new { t.Id, t.Topic })
					.ToListAsync();

				return Results.Ok(new
				{
					value = threads
				});
			});

			app.MapPost(
				"/chat/threads/{chatThreadId}/participants/:add",
				[Authorize] async (ClaimsPrincipal principal, AcsDbContext db, string chatThreadId, AddChatParticipantsRequest req) =>
				{
					string userRawId = principal.Claims.First(x => x.Type == "skypeid").Value;

					var thisThread = await db.ChatThreads
						.Include(t => t.Participants)
						.Include(t => t.UserChatThreads)
						.FirstOrDefaultAsync(t => t.Id == chatThreadId);

					var user = await db.Users
						.Include(u => u.Threads)
						.Include(u => u.UserChatThreads)
						.FirstOrDefaultAsync(u => u.RawId == userRawId);

					if (thisThread == null)
					{
						return Results.NotFound();
					}

					if (user == null)
					{
						return Results.Forbid();
					}

					if (thisThread.CreatedBy.RawId != userRawId)
					{
						return Results.Forbid();
					}

					foreach (var requestParticipant in req.Participants)
					{
						// TODO: Not efficient to look up in a loop
						var participantToAdd = await db.Users
							.Include(u => u.Threads)
							.Include(u => u.UserChatThreads)
							.FirstOrDefaultAsync(u => u.RawId == requestParticipant.CommunicationIdentifier.RawId);

						if (participantToAdd == null)
						{
							// TODO: add to "invalidParticipants"
							continue;
						}

						var uct = new UserChatThread
						{
							User = participantToAdd,
							ChatThread = thisThread,

							ShareHistoryTime = requestParticipant.ShareHistoryTime,
							DisplayName = requestParticipant.DisplayName
						};

						thisThread.Participants.Add(participantToAdd);
						thisThread.UserChatThreads.Add(uct);

						participantToAdd.Threads.Add(thisThread);
						participantToAdd.UserChatThreads.Add(uct);
					}

					db.SaveChanges();

					// TODO: why does Swagger say it should return 201?
					return Results.Created($"/chat/threads/{chatThreadId}/participants", new {});
				});
		}
	}
}
