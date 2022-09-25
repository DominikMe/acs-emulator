﻿using AcsEmulatorAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
						db,
						async () =>
						{
							return await db.ChatThreads
								.Include(t => t.Participants)
								.Include(t => t.UserChatThreads)
								.FirstOrDefaultAsync(t => t.Id == chatThreadId);
						});

					if (context is ThreadRequestValidContext (User thisUser, ChatThread thisThread))
					{
						await thisThread.AddParticipants(db, thisUser, req.Participants);

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
						db,
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
							communicationUserIdentifier = new CommunicationIdentifier(uct.UserId),
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
						db,
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
						int nextSequenceId = thisThread.Messages.Count + 1;
						var msg = new ChatMessage
						{
							Content = req.Content,
							Sender = thisUser,
							SenderDisplayName = req.SenderDisplayName,
							Type = req.Type ?? ChatMessageType.Text,
							SequenceId = nextSequenceId
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
						db,
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

								// TODO: how to Enum.ToString() camelCase instead of PascalCase?
								type = m.Type switch
								{
									ChatMessageType.Text => "text",
									ChatMessageType.ParticipantAdded => "participantAdded",
									_ => "text"
								},

								sequenceId = m.SequenceId.ToString(),

								// TODO
								versionId = "1",

								content = new
								{
									message = m.Content,

									participants = m switch
									{
										AddParticipantsChatMessage msg => msg.AddedParticipants
											.Select(p => new
											{
												communicationIdentifier = new CommunicationIdentifier(p.Participant.RawId),												
												p.DisplayName,
												p.ShareHistoryTime
											}),

										// TODO: support participants removed
										_ => null
									}

									// TODO: support "topic updated"
									// topic = msg.Topic
								},

								m.SenderDisplayName,

								m.CreatedOn,

								senderCommunicationIdentifier = new CommunicationIdentifier(m.Sender.RawId)
							});

						return Results.Ok(new
						{
							value = messages
						});

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
			AcsDbContext db,
			Func<Task<ChatThread?>> getThread)
		{
			string userRawId = principal.Claims.First(x => x.Type == "skypeid").Value;
			
			var thisUser = await db.Users.FindAsync(userRawId);
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