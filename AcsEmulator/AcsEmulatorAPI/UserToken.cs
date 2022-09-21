using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AcsEmulatorAPI
{
	static class UserToken
	{
		public static string GenerateJwtToken(string signingKey, string resourceId, string identity, string[] scopes, DateTime expires)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(signingKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] 
				{
					new Claim("skypeid", identity),
					new Claim("resourceId", resourceId),
					new Claim("acsScope", string.Join(" ", scopes))
				}),
				Expires = expires,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public static TokenValidationParameters GetTokenValidationParameters(string jwtSigningKey) => new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSigningKey)),
			ValidateIssuer = false,
			ValidateAudience = false,
			// set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
			ClockSkew = TimeSpan.Zero
		};

		// todo use to validate acsScope for chat
		public static bool HasAcsScope(IEnumerable<Claim> claims, string scope) => claims.First(x => x.Type == "acsScope").Value.Split(" ").Any(x => x == scope);
	}
}