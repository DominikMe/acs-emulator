using AcsEmulatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcsEmulatorAPI
{
	// https://github.com/Azure/azure-rest-api-specs/blob/main/specification/communication/data-plane/Chat/stable/2021-09-07/communicationserviceschat.json
	public static class Chat
	{
		public static void AddChatEndpoints(this WebApplication app)
		{
			app.MapPost("/chat/threads", async (HttpContext context, AcsDbContext db, CreateChatThreadRequest req) =>
			{
				string userRawId = GetRawId(context, app.Configuration);

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

			app.MapGet("/chat/threads", async (HttpContext context, AcsDbContext db) =>
			{
				string userRawId = GetRawId(context, app.Configuration);

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
				async (HttpContext context, AcsDbContext db, string chatThreadId, AddChatParticipantsRequest req) =>
				{
					string userRawId = GetRawId(context, app.Configuration);

					var thisThread = await db.ChatThreads.FindAsync(chatThreadId);

					if (thisThread == null)
					{
						return Results.NotFound();
					}

					if (thisThread.CreatedBy.RawId != userRawId)
					{
						return Results.Forbid();
					}

					return Results.Ok();

					//var idsToAdd = req.Participants.Select(p => p.)
					//var participantsToAdd = db.Users.Where(u => req.Participants.)
				});
		}

		private static string GetRawId(HttpContext context, IConfiguration config)
		{
			var token = context.Request.Headers.Authorization.First().Split("Bearer ")[1];
			var parsedToken = UserToken.ValidateJwtToken(config["JwtSigningKey"], token);
			return parsedToken.skypeid;
		}
	}
}
