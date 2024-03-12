using AcsEmulatorAPI.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;



namespace AcsEmulatorAPI
{
    [TestClass()]
    public class IdentityServiceTests
    {
        private readonly WebApplicationFactory<Program> _factory;
        public IdentityServiceTests()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        record TokenResponse(string token, string expiresOn);

        // Since identities are stateful, this is more an end-to-end test than an unit one.
        // Having a class to represent identities and extract code outside of route mapping would help
        [TestMethod()]
        public void AddIdentityTest()
        {
            var client = _factory.CreateClient();

            var response = client.PostAsJsonAsync("/identities/", new CreateIdentityRequest([IdentityTokenScope.Chat])).Result;
            //Console.WriteLine(response);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            var location = response.Headers.Location;
            Assert.IsNotNull(location);
            // Check Identity API returns an ACS Identity
            Assert.IsTrue(location.ToString().StartsWith("/identities/8:acs:", StringComparison.InvariantCulture));

            // Now ask a Token on the 8:acs: identity
            var token = client.PostAsJsonAsync(location + "/:issueAccessToken", new IssueTokenRequest([IdentityTokenScope.Chat], 60)).Result;
            Assert.AreEqual(HttpStatusCode.OK, token.StatusCode);
            //Console.WriteLine(token.Content.ReadAsStringAsync().Result);
            TokenResponse? tokenResponse = token.Content.ReadFromJsonAsync<TokenResponse>().Result;

            Assert.IsNotNull(tokenResponse);
            // Token should be a long string
            Assert.IsTrue(tokenResponse.token.Length > 300);

            var expiresOn = DateTimeOffset.Parse(tokenResponse.expiresOn);
            var utcNow = DateTimeOffset.UtcNow;
            // expiresOn should be a date in the next hour
            Assert.IsTrue(expiresOn > utcNow.AddMinutes(58) && expiresOn < utcNow.AddMinutes(120));

            // Check the identity exists, using the emulator GET identity API
            var identity = client.GetAsync(location).Result;
            Assert.AreEqual(HttpStatusCode.OK, identity.StatusCode);

            // Now delete the identity (revoke token is a no-op for now, also issueAccessToken do not check id exists)
            var deleteIdetity = client.DeleteAsync(location).Result;
            Assert.AreEqual(HttpStatusCode.NoContent, deleteIdetity.StatusCode);

            // Check the identity is gone, using the emulator GET identity API
            var identity2 = client.GetAsync(location).Result;
            Assert.AreEqual(HttpStatusCode.NotFound, identity2.StatusCode);

        }
    }
}