using AcsEmulatorAPI.Models;

namespace AcsEmulatorAPI
{
	// https://github.com/Azure/azure-rest-api-specs/blob/main/specification/communication/data-plane/Chat/stable/2021-09-07/communicationserviceschat.json
	public static class Chat
	{
		public static void AddChatEndpoints(this WebApplication app)
		{
			app.MapPost("/chat/threads", async (AcsDbContext db, CreateChatThreadRequest req) =>
			{
				var t = ChatThread.CreateNew(req.Topic);

				await db.ChatThreads.AddAsync(t);
				await db.SaveChangesAsync();

				var result = new CreateChatThreadResult
				{
					ChatThread = new ChatThreadProperties
					{
						Id = t.Id,
						Topic = t.Topic,
						CreatedOn = t.CreatedOn,
						CreatedByCommunicationIdentifier = new CommunicationIdentifier
						{
							// Todo: use user id from token
							RawId = User.CreateNew().RawId
						}
					}
				};

				return Results.Created($"/chat/threads/{t.Id}", result);
			});
		}
	}
}
