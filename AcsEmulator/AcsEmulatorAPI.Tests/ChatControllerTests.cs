using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using AcsEmulatorAPI.Models;

namespace AcsEmulatorAPI.Tests
{
    [TestClass()]
    public class ChatControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private string _authToken;

        public ChatControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestInitialize]
        public async Task Initialize()
        {
            // If Identity Unit tests is passing, below code will work
            var identity = await _client.PostAsJsonAsync("/identities/", new CreateIdentityRequest([IdentityTokenScope.Chat]));
            var token = await _client.PostAsJsonAsync(identity.Headers.Location + "/:issueAccessToken", new IssueTokenRequest([IdentityTokenScope.Chat], 60));
            var tokenResponse = await token.Content.ReadFromJsonAsync<IdentityTokenResponse>();
            Assert.IsNotNull(tokenResponse);
            _authToken = tokenResponse.token;
        }

        [TestCleanup]
        public void Cleanup()
        {
            _client.Dispose();
        }

        [TestMethod()]
        public async Task AddChatEndpointsTest()
        {
            // Check if the /chat/threads endpoint is protected
            var response = await _client.PostAsJsonAsync("/chat/threads", new CreateChatThreadRequest("Test Topic", new List<ChatParticipant>()));
            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);

            // Add default Authorize header
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authToken);

            // Create a New chat thread
            response = await _client.PostAsJsonAsync("/chat/threads", new CreateChatThreadRequest("Test Topic", new List<ChatParticipant>()));
            Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);

            string value = await response.Content.ReadAsStringAsync();
            Console.WriteLine(value);
            var chatThreadCreation = await response.Content.ReadFromJsonAsync<ChatThreadCreation>();
            Assert.IsNotNull(chatThreadCreation);
            var chatThreadInfo = chatThreadCreation.ChatThread;
            // id must start with 19:
            Assert.IsTrue(chatThreadInfo.Id.StartsWith("19:"));
            Assert.AreEqual("Test Topic", chatThreadInfo.Topic);


            // Call Get /chat/threads
            var chatThreads = await _client.GetFromJsonAsync<ChatThreadInfo>("/chat/threads");
            Assert.IsNotNull(chatThreads);
            var firstChatThread = chatThreads.Value.First();
            Assert.AreEqual(chatThreadInfo.Id, firstChatThread.Id);
            Assert.AreEqual(chatThreadInfo.Topic, firstChatThread.Topic);

            // Call Get /chat/threads/{chatThreadInfo.Id}
            var chatThread = await _client.GetFromJsonAsync<ChatThreadCreationInfo>($"/chat/threads/{chatThreadInfo.Id}");
            Assert.IsNotNull(chatThread);
            Assert.AreEqual(chatThreadInfo.Id, chatThread.Id);

            // Test the Get on admin chat endpoint
            var adminChatThreads = await _client.GetFromJsonAsync<ChatThreadInfo>("/admin/chat/threads");
            Assert.IsNotNull(adminChatThreads);
            // Admin chat thread can show more info depending on DB, look for the specific Id
            Assert.IsTrue(adminChatThreads.Value.Any(x => x.Id == chatThreadInfo.Id));
        }
    }
}