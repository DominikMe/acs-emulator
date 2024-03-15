using AcsEmulatorAPI.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AcsEmulatorAPI.Tests
{
    [TestClass()]
    public class CallAutomationControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public CallAutomationControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestMethod()]
        public async Task CreateCallConnectionTest()
        {
            // Arrange
            var sourceCallerIdNumber = new PhoneNumber("+19988877766");
            var targetPhoneNumber = new PhoneNumber("+17781234567");
            var target = new CommunicationIdentifier(targetPhoneNumber);
            var callbackUri = "myCallback";

            // Act
            var response = await _client.PostAsJsonAsync(
                "/calling/callConnections",
                new CreateCallRequest(callbackUri, new List<CommunicationIdentifier> { target })  { SourceCallerIdNumber = sourceCallerIdNumber }
            );

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);

            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            var callConnectionCreation = await response.Content.ReadFromJsonAsync<CallConnectionProperties>();
            Assert.IsNotNull(callConnectionCreation);
            Assert.AreEqual(callbackUri, callConnectionCreation.CallbackUri);
            Assert.AreEqual(CallConnectionState.Connecting, callConnectionCreation.CallConnectionState);
            Assert.AreEqual(target.RawId, callConnectionCreation.Targets.First().RawId);
            Assert.AreEqual(sourceCallerIdNumber.Value, callConnectionCreation.SourceCallerIdNumber?.Value);
        }
    }
}