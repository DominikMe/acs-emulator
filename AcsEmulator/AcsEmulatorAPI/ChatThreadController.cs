using AcsEmulatorAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Reflection.Metadata.Ecma335;

namespace AcsEmulatorAPI
{
	public static class ChatThreadController
	{
		record ThreadRequestContext;

		record ThreadRequestErrorContext(IResult ErrorResult) : ThreadRequestContext;
		record ThreadRequestValidContext(User ThisUser, ChatThread ThisThread): ThreadRequestContext;

		public static void AddChatThreadEndpoints(this WebApplication app)
		{
			app.MapPost(
				"/chat/threads/{chatThreadId}/participants/:add",
				[Authorize] async (ClaimsPrincipal principal, AcsDbContext db, string chatThreadId, AddChatParticipantsRequest req) =>
				{
					var context = await GetRequestContext(
						principal,
						async (userId) =>
						{
							return await db.Users
								.Include(u => u.Threads)
								.Include(u => u.UserChatThreads)
								.FirstOrDefaultAsync(u => u.RawId == userId);
						},
						async () =>
						{
							return await db.ChatThreads
								.Include(t => t.Participants)
								.Include(t => t.UserChatThreads)
								.FirstOrDefaultAsync(t => t.Id == chatThreadId);
						});

					if (context is ThreadRequestValidContext (_, ChatThread thisThread))
					{
						await thisThread.AddParticipants(db, req.Participants);

						await db.SaveChangesAsync();

						// TODO: why does Swagger say it should return 201?
						return Results.Created($"/chat/threads/{chatThreadId}/participants", new { });
					}
					else if (context is ThreadRequestErrorContext err)
					{
						return err.ErrorResult;
					}
					else
					{
						throw new Exception($"Unexpected context type: {context.GetType()}");
					}
				});

			app.MapGet(
				"/chat/threads/{chatThreadId}/participants",
				[Authorize] async (ClaimsPrincipal principal, AcsDbContext db, string chatThreadId) =>
				{
					var context = await GetRequestContext(
						principal,
						async (userId) => await db.Users.FindAsync(userId),
						async () =>
						{
							return await db.ChatThreads
								.Include(t => t.Participants)
								.Include(t => t.UserChatThreads)
								.FirstOrDefaultAsync(t => t.Id == chatThreadId);
						});

					if (context is ThreadRequestValidContext(_, ChatThread thisThread))
					{
						var participants = thisThread.UserChatThreads.Select(uct => new
						{
							communicationUserIdentifier = uct.UserId,
							uct.DisplayName,
							uct.ShareHistoryTime
						});

						// TODO: paging
						return Results.Ok(new { value = participants });
					}
					else if (context is ThreadRequestErrorContext err)
					{
						return err.ErrorResult;
					}
					else
					{
						throw new Exception($"Unexpected context type: {context.GetType()}");
					}
				});

			app.MapPost(
				"/chat/threads/{chatThreadId}/messages",
				[Authorize] async (ClaimsPrincipal principal, AcsDbContext db, string chatThreadId, SendChatMessageRequest req) =>
				{
					var context = await GetRequestContext(
						principal,
						async (userId) => await db.Users.FindAsync(userId),
						async () =>
						{
							return await db.ChatThreads
								.Include(t => t.Participants)
								.Include(t => t.UserChatThreads)
								.Include(t => t.Messages)
								.FirstOrDefaultAsync(t => t.Id == chatThreadId);
						});

					if (context is ThreadRequestValidContext(User thisUser, ChatThread thisThread))
					{
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
					}
					else if (context is ThreadRequestErrorContext err)
					{
						return err.ErrorResult;
					}
					else
					{
						throw new Exception($"Unexpected context type: {context.GetType()}");
					}
				});

			app.MapGet(
				"/chat/threads/{chatThreadId}/messages",
				[Authorize] async (ClaimsPrincipal principal, AcsDbContext db, string chatThreadId) =>
				{
					var context = await GetRequestContext(
						principal,
						async (userId) => await db.Users.FindAsync(userId),
						async () =>
						{
							return await db.ChatThreads
								.Include(t => t.Participants)
								.Include(t => t.Messages)
								.FirstOrDefaultAsync(t => t.Id == chatThreadId);
						});

					if (context is ThreadRequestValidContext(_, ChatThread thisThread))
					{
						var messages = thisThread.Messages
							.Select(m => new
							{
								m.Id,

								// TODO: convert enum properly
								type = "text",

								// TODO
								sequenceId = "1",

								// TODO
								versionId = "1",

								// TODO: support other message types (topic updated, participants updated)
								content = new
								{
									message = m.Content
								},

								m.SenderDisplayName,

								m.CreatedOn,

								senderCommunicationIdentifier = new
								{
									rawId = m.Sender.RawId
								}
							});

						return Results.Ok(messages);
					}
					else if (context is ThreadRequestErrorContext err)
					{
						return err.ErrorResult;
					}
					else
					{
						throw new Exception($"Unexpected context type: {context.GetType()}");
					}
				});
		}

		private static async Task<ThreadRequestContext> GetRequestContext(
			ClaimsPrincipal principal,
			Func<string, Task<User?>> getUser,
			Func<Task<ChatThread?>> getThread)
		{
			string userRawId = principal.Claims.First(x => x.Type == "skypeid").Value;
			
			var thisUser = await getUser(userRawId);
			var thisThread = await getThread();

			if (thisThread == null)
			{
				return new ThreadRequestErrorContext(Results.NotFound());
			}
			else if (thisUser == null)
			{
				return new ThreadRequestErrorContext(Results.Forbid());
			}
			else if (!thisThread.Participants.Any(p => p.RawId == userRawId)) // Current user is not a participant in the requested thread
			{
				return new ThreadRequestErrorContext(Results.Forbid());
			}

			return new ThreadRequestValidContext(thisUser, thisThread);
		}
	}
}
