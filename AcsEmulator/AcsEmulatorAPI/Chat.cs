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

					// Current user is not a participant in the requested thread
					if (!thisThread.Participants.Any(p => p.RawId == userRawId))
					{
						return Results.Forbid();
					}

					await thisThread.AddParticipants(db, req.Participants);

					await db.SaveChangesAsync();

					// TODO: why does Swagger say it should return 201?
					return Results.Created($"/chat/threads/{chatThreadId}/participants", new {});
				});

			app.MapGet(
				"/chat/threads/{chatThreadId}/participants",
				[Authorize] async (ClaimsPrincipal principal, AcsDbContext db, string chatThreadId) =>
				{
					string userRawId = principal.Claims.First(x => x.Type == "skypeid").Value;

					var thisThread = await db.ChatThreads
						.Include(t => t.Participants)
						.Include(t => t.UserChatThreads)
						.FirstOrDefaultAsync(t => t.Id == chatThreadId);

					var user = await db.Users.FindAsync(userRawId);

					if (thisThread == null)
					{
						return Results.NotFound();
					}

					if (user == null)
					{
						return Results.Forbid();
					}

					// Current user is not a participant in the requested thread
					if (!thisThread.Participants.Any(p => p.RawId == userRawId))
					{
						return Results.Forbid();
					}

					var participants = thisThread.UserChatThreads.Select(uct => new
						{
							communicationUserIdentifier = uct.UserId,
							uct.DisplayName,
							uct.ShareHistoryTime
						});

					// TODO: paging
					return Results.Ok(new { value = participants });
				});

			app.MapPost(
				"/chat/threads/{chatThreadId}/messages",
				[Authorize] async (ClaimsPrincipal principal, AcsDbContext db, string chatThreadId, SendChatMessageRequest req) =>
				{
					string userRawId = principal.Claims.First(x => x.Type == "skypeid").Value;

					var thisThread = await db.ChatThreads
						.Include(t => t.Participants)
						.Include(t => t.UserChatThreads)
						.Include(t => t.Messages)
						.FirstOrDefaultAsync(t => t.Id == chatThreadId);

					var thisUser = await db.Users.FindAsync(userRawId);

					if (thisThread == null)
					{
						return Results.NotFound();
					}

					if (thisUser == null)
					{
						return Results.Forbid();
					}

					// Current user is not a participant in the requested thread
					if (!thisThread.Participants.Any(p => p.RawId == userRawId))
					{
						return Results.Forbid();
					}

					var msg = new ChatMessage
					{
						Content = req.Content,
						Sender = thisUser,
						SenderDisplayName = req.SenderDisplayName,
						Type = req.Type ?? ChatMessageType.Text
					};
					thisThread.Messages.Add(msg);

					await db.SaveChangesAsync();

					return Results.Created(
						$"/chat/threads/{chatThreadId}/messages/{msg.Id}",
						new { msg.Id });
				});
		}
	}
}
