using AcsEmulatorAPI.Models;

namespace AcsEmulatorAPI
{
	// https://github.com/Azure/azure-rest-api-specs/blob/main/specification/communication/data-plane/Chat/stable/2021-09-07/communicationserviceschat.json
	public static class Chat
	{
		public static void AddChatEndpoints(this WebApplication app)
		{
			app.MapPost("/chat/threads", async (HttpContext context, AcsDbContext db, CreateChatThreadRequest req) =>
			{
				var t = ChatThread.CreateNew(req.Topic);

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
							RawId = GetRawId(context)
						}
					}
				};

				return Results.Created($"/chat/threads/{t.Id}", result);
			});
		}

		private static string GetRawId(HttpContext context)
		{
			var auth = context.Request.Headers.Authorization;
			return "123";
		}
	}
}
