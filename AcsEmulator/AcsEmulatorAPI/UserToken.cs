using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AcsEmulatorAPI
{
	record UserToken(string skypeid, string resourceId, string acsScope)
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

		// todo add proper auth middleware
		public static UserToken ValidateJwtToken(string signingKey, string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(signingKey);
			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					// set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
					ClockSkew = TimeSpan.Zero
				}, out SecurityToken validatedToken);

				var jwtToken = (JwtSecurityToken)validatedToken;
				var skypeid = jwtToken.Claims.First(x => x.Type == "skypeid").Value;
				var resourceId = jwtToken.Claims.First(x => x.Type == "resourceId").Value;
				var acsScope = jwtToken.Claims.First(x => x.Type == "acsScope").Value;

				return new UserToken(skypeid, resourceId, acsScope);
			}
			catch
			{
				Console.Error.WriteLine("Token failed validation");
				throw;
			}
		}
	}
}