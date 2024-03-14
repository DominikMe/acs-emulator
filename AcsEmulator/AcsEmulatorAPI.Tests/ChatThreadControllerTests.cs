using Microsoft.AspNetCore.Mvc.Testing;
using AcsEmulatorAPI.Models;
using System.Net.Http.Json;

namespace AcsEmulatorAPI.Tests
{
    [TestClass()]
    public class ChatThreadControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        private ChatThreadCreationInfo _chatThreadCreationInfo;

        public ChatThreadControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestInitialize]
        public async Task Initialize()
        {
            // If Identity And ChatController Unit tests are passing, below code will work
            var identity1 = await _client.PostAsJsonAsync("/identities/", new CreateIdentityRequest([IdentityTokenScope.Chat]));
            var token = await _client.PostAsJsonAsync(identity1.Headers.Location + "/:issueAccessToken", new IssueTokenRequest([IdentityTokenScope.Chat], 60));
            var tokenResponse = await token.Content.ReadFromJsonAsync<IdentityTokenResponse>();
            Assert.IsNotNull(tokenResponse);
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenResponse.token);
            // Create a New chat thread
            var chatThread = await _client.PostAsJsonAsync("/chat/threads", new CreateChatThreadRequest("Test Topic", new List<ChatParticipant>()));
            Assert.IsNotNull(chatThread);
            var chatThreadInfo = await chatThread.Content.ReadFromJsonAsync<ChatThreadCreation>();
            Assert.IsNotNull(chatThreadInfo);
            _chatThreadCreationInfo = chatThreadInfo.ChatThread;
        }

        [TestCleanup]
        public void Cleanup()
        {
            _client.Dispose();
        }

        [TestMethod()]
        public async Task AddChatThreadEndpointsTest()
        {
            var identity2 = await _client.PostAsJsonAsync("/identities/", new CreateIdentityRequest([IdentityTokenScope.Chat]));
            // Get everything right of /identities/ prefix from the location
            var identity2Str = identity2.Headers.Location?.ToString().Split("/identities/")[1];
            Assert.IsNotNull(identity2Str);

            var participant2 = new ChatParticipant(
                new CommunicationIdentifier(identity2Str), "John Doe", DateTimeOffset.UtcNow);

            // Call add participant to chat thread
            var addParticipant = await _client.PostAsJsonAsync($"/chat/threads/{_chatThreadCreationInfo.Id}/participants/:add",
                                  new AddChatParticipantsRequest([participant2]));
            Assert.AreEqual(System.Net.HttpStatusCode.Created, addParticipant.StatusCode);
            // Get Participants

            var getParticipants = await _client.GetFromJsonAsync<ChatParticipantsInfo>($"/chat/threads/{_chatThreadCreationInfo.Id}/participants");
            Assert.IsNotNull(getParticipants);
            // Assert there is 2 participants:
            Assert.IsTrue(getParticipants.Value.Count == 2);
            // Assert any of the participants is the one we added
            Assert.IsTrue(getParticipants.Value.Any(x => x.CommunicationIdentifier.RawId == identity2Str));

            // Sends a Message
            var message = await _client.PostAsJsonAsync($"/chat/threads/{_chatThreadCreationInfo.Id}/messages",
                               new SendChatMessageRequest("Hello World", "John Doe", ChatMessageType.Text));
            Assert.AreEqual(System.Net.HttpStatusCode.Created, message.StatusCode);

            // Get Messages
            var getMessages = await _client.GetStringAsync($"/chat/threads/{_chatThreadCreationInfo.Id}/messages");
            Assert.IsNotNull(getMessages);
            Assert.IsTrue(getMessages.Contains("Hello World"));
            
        }
    }
}