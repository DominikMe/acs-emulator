using AcsEmulatorAPI.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace AcsEmulatorAPI.Tests
{
    [TestClass()]
    public class IdentityServiceTests
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;


        public IdentityServiceTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _client.Dispose();
        }


        // Since identities are stateful, this is more an end-to-end test than an unit one.
        // Having a class to represent identities and extract code outside of route mapping would help
        [TestMethod()]
        public async Task AddIdentityTest()
        {
            var response = await _client.PostAsJsonAsync("/identities/", new CreateIdentityRequest([IdentityTokenScope.Chat]));
            //Console.WriteLine(response);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            var location = response.Headers.Location;
            Assert.IsNotNull(location);
            // Check Identity API returns an ACS Identity
            Assert.IsTrue(location.ToString().StartsWith("/identities/8:acs:", StringComparison.InvariantCulture));

            // Now ask a Token on the 8:acs: identity
            var token = await _client.PostAsJsonAsync(location + "/:issueAccessToken", new IssueTokenRequest([IdentityTokenScope.Chat], 60));
            Assert.AreEqual(HttpStatusCode.OK, token.StatusCode);
            //Console.WriteLine(token.Content.ReadAsStringAsync().Result);
            IdentityTokenResponse? tokenResponse = await token.Content.ReadFromJsonAsync<IdentityTokenResponse>();

            Assert.IsNotNull(tokenResponse);
            // Token should be a long string
            Assert.IsTrue(tokenResponse.token.Length > 300);

            var expiresOn = DateTimeOffset.Parse(tokenResponse.expiresOn);
            var utcNow = DateTimeOffset.UtcNow;
            // expiresOn should be a date in the next hour
            Assert.IsTrue(expiresOn > utcNow.AddMinutes(58) && expiresOn < utcNow.AddMinutes(120));

            // Check the identity exists, using the emulator GET identity API
            var identity = await _client.GetAsync(location);
            Assert.AreEqual(HttpStatusCode.OK, identity.StatusCode);

            // Now delete the identity (revoke token is a no-op for now, also issueAccessToken do not check id exists)
            var deleteIdetity = await _client.DeleteAsync(location);
            Assert.AreEqual(HttpStatusCode.NoContent, deleteIdetity.StatusCode);

            // Check the identity is gone, using the emulator GET identity API
            var identity2 = await _client.GetAsync(location);
            Assert.AreEqual(HttpStatusCode.NotFound, identity2.StatusCode);

        }
    }
}