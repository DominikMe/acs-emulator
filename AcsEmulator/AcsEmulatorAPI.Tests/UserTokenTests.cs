using AcsEmulatorAPI.Endpoints.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AcsEmulatorAPI.Tests
{
    [TestClass()]
    public class UserTokenTests
    {
        private readonly string signingKey;
        private readonly string generatedToken;

        public UserTokenTests()
        {
            signingKey = "aaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbccccccccccccccccccdddddddddddddddddddddddddddddddddddddddaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbccccccccccccccccccddddddddddddddddddddddddddddddddddddddd";
            generatedToken = UserToken.GenerateJwtToken(signingKey, "resourceId", "SkypeTokIdentity", ["VoIP"], DateTime.Today.AddDays(1));
        }

        [TestMethod()]
        public void GenerateJwtTokenTest()
        {
            Assert.IsNotNull(generatedToken);

            var tokenHandler = new JwtSecurityTokenHandler();
            var parsedToken = tokenHandler.ReadJwtToken(generatedToken);
            Assert.AreEqual("SkypeTokIdentity", parsedToken.Claims.First(x => x.Type == "skypeid").Value);
            Assert.AreEqual("resourceId", parsedToken.Claims.First(x => x.Type == "resourceId").Value);
            Assert.AreEqual("VoIP", parsedToken.Claims.First(x => x.Type == "acsScope").Value);
        }

        [TestMethod()]
        public void GetTokenValidationParametersTest()
        {
            var tokenVal = UserToken.GetTokenValidationParameters(signingKey);
            Assert.IsTrue(tokenVal.ValidateIssuerSigningKey);
            Assert.IsFalse(tokenVal.ValidateIssuer);
            Assert.IsFalse(tokenVal.ValidateAudience);
            Assert.AreEqual(TimeSpan.Zero, tokenVal.ClockSkew);
            var SymmetricKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signingKey));
            Assert.AreEqual(SymmetricKey.ToString(), tokenVal.IssuerSigningKey.ToString());
        }

        [TestMethod()]
        public void HasAcsScopeTest()
        {
            var containsAcsVoIP = new ClaimsIdentity(new[]
                {
                    new Claim("claim1", "claim1"),
                    new Claim("resourceId", "myResource"),
                    new Claim("acsScope", "VoIP")
                });

            Assert.IsTrue(UserToken.HasAcsScope(containsAcsVoIP.Claims, "VoIP"));
            Assert.IsFalse(UserToken.HasAcsScope(containsAcsVoIP.Claims, "otherClaim"));

            var noACS = new ClaimsIdentity(new[]
                {
                    new Claim("claim1", "claim1"),
                    new Claim("resourceId", "myResource"),
                });

            Assert.IsFalse(UserToken.HasAcsScope(noACS.Claims, "VoIP"));
        }

        [TestMethod()]
        public void EndToEndTest()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = UserToken.GetTokenValidationParameters(signingKey);
            var principal = tokenHandler.ValidateToken(generatedToken, validationParameters, out var validatedToken);
            Assert.IsNotNull(principal);
            Assert.IsNotNull(validatedToken);
        }
    }
}