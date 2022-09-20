using AcsEmulatorAPI.Models;

namespace AcsEmulatorAPI
{
	// https://github.com/Azure/azure-rest-api-specs/tree/main/specification/communication/data-plane/Identity/stable/2022-10-01
	public static class Identity
	{
		public static void AddIdentity(this WebApplication app)
		{

			app.MapPost("/identities", dynamic (AcsDbContext db, CreateIdentityRequest? req) =>
			{
				var user = CreateAndPersistUser(db);

				var identity = user.RawId;

				if (req == null || req.createTokenWithScopes == null || req.createTokenWithScopes.Length == 0)
					return new { identity };

				var accessToken = CreateNewToken(identity, req.createTokenWithScopes);
				return new
				{
					identity,
					accessToken
				};
			});

			app.MapPost("/identities/{id}/:issueAccessToken", (IssueTokenRequest req, string id) => CreateNewToken(id, req.scopes, req.expiresInMinutes));

			app.MapPost("/identities/{id}/:revokeAccessTokens", (string id) => Results.StatusCode(204));
		}

		private static dynamic CreateNewToken(string identity, string[] scopes, int? expiresInMinutes = 60) => new
		{
			token = "token", // todo: return a real jwt with skypeid, exp and acsScopes
			expiresOn = DateTimeOffset.UtcNow.AddMinutes((double)(expiresInMinutes ?? 60)).ToString("o"),
		};

		private static User CreateAndPersistUser(AcsDbContext db)
		{
			var u = User.CreateNew();

			db.Users.Add(u);
			db.SaveChanges();

			return u;
		}

		record CreateIdentityRequest(string[]? createTokenWithScopes);

		record IssueTokenRequest(string[] scopes, int? expiresInMinutes);
	}
}
