using AcsEmulatorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcsEmulatorAPI
{
    // https://github.com/Azure/azure-rest-api-specs/blob/main/specification/communication/data-plane/Identity/stable/2022-10-01/CommunicationIdentity.json
    public static class IdentityService
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
					identity = new Identity(user.RawId),
					accessToken
				});
			});

			app.MapPost("/identities/{id}/:issueAccessToken", (IssueTokenRequest req, string id) => CreateNewToken(jwtSigningKey, resourceId, id, req.scopes, req.expiresInMinutes));

			app.MapPost("/identities/{id}/:revokeAccessTokens", (string id) => Results.NoContent());

			app.MapDelete("/identities/{id}", async (AcsDbContext db, string id) =>
			{
				var user = await db.Users
						.FirstOrDefaultAsync(x => x.RawId == id);
				if (user is null)
					return Results.NoContent();

				// todo: is there a more efficient way without doing the prior lookup?
				db.Users.Remove(user);
				await db.SaveChangesAsync();

				return Results.NoContent();
			});

			// Experimental API: emulator api, hopefully soon added to ACS
			app.MapGet("/identities/{id}", async (AcsDbContext db, string id) =>
			{
				var user = await db.Users
						.FirstOrDefaultAsync(x => x.RawId == id);
				if (user is null)
					return Results.NotFound();
				return Results.Ok(new { identity = new Identity(id) });
			});

			// Experimental API: emulator api, hopefully soon added to ACS
			app.MapGet("/identities", async (AcsDbContext db) =>
			{
				// todo: if we stored resourceId with the user we could support multi-tenant / multi-resource scenarios with the emulator - basically a resource as a working set
				var users = await db.Users.Select(x => new Identity(x.RawId)).ToListAsync();
				return Results.Ok(new { value = users });
			});
		}

		private static dynamic CreateNewToken(string signingKey, string resourceId, string identity, IdentityTokenScope[] tokenSopes, int? expiresInMinutes = 60)
		{
			var expires = DateTime.UtcNow.AddMinutes(expiresInMinutes ?? 60);
			var scopes = tokenSopes.Select(x => x.ToString()).ToArray();
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
	}
}
