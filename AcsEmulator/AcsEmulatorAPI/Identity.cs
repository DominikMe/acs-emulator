using AcsEmulatorAPI.Models;

namespace AcsEmulatorAPI
{
	// https://github.com/Azure/azure-rest-api-specs/tree/main/specification/communication/data-plane/Identity/stable/2022-10-01
	public static class Identity
	{
		public static void AddIdentity(this WebApplication app)
		{
			var jwtSigningKey = app.Configuration["JwtSigningKey"];
			var resourceId = app.Configuration["ResourceId"];

			app.MapPost("/identities", dynamic (AcsDbContext db, CreateIdentityRequest? req) =>
			{
				var user = CreateAndPersistUser(db, resourceId);

				if (req == null || req.createTokenWithScopes == null || req.createTokenWithScopes.Length == 0)
					return Results.Created($"/identities/{user.RawId}", new { identity = new { id = user.RawId } });

				var accessToken = CreateNewToken(jwtSigningKey, resourceId, user.RawId, req.createTokenWithScopes);
				return Results.Created($"/identities/{user.RawId}", new
				{
					identity = new
					{
						id = user.RawId
					},
					accessToken
				});
			});

			app.MapPost("/identities/{id}/:issueAccessToken", (IssueTokenRequest req, string id) => CreateNewToken(jwtSigningKey, resourceId, id, req.scopes, req.expiresInMinutes));

			app.MapPost("/identities/{id}/:revokeAccessTokens", (string id) => Results.StatusCode(204));
		}

		private static dynamic CreateNewToken(string signingKey, string resourceId, string identity, string[] scopes, int? expiresInMinutes = 60)
		{
			var expires = DateTime.UtcNow.AddMinutes(expiresInMinutes ?? 60);
			var token = UserToken.GenerateJwtToken(signingKey, resourceId, identity, scopes, expires);

			return new
			{
				token = token,
				expiresOn = expires.ToString("o")
			};
		}

		private static User CreateAndPersistUser(AcsDbContext db, string resourceId)
		{
			var u = User.CreateNew(resourceId);

			db.Users.Add(u);
			db.SaveChanges();

			return u;
		}

		record CreateIdentityRequest(string[]? createTokenWithScopes);

		record IssueTokenRequest(string[] scopes, int? expiresInMinutes);
	}
}
