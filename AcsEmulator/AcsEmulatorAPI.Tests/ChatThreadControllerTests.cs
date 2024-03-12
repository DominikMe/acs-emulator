using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcsEmulatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using AcsEmulatorAPI.Models;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;

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
            // If Identity And ChatController Unit tests are passing, below code will work
            var identity1 = _client.PostAsJsonAsync("/identities/", new CreateIdentityRequest([IdentityTokenScope.Chat])).Result;
            var token = _client.PostAsJsonAsync(identity1.Headers.Location + "/:issueAccessToken", new IssueTokenRequest([IdentityTokenScope.Chat], 60)).Result;
            var tokenResponse = token.Content.ReadFromJsonAsync<IdentityTokenResponse>().Result;
            Assert.IsNotNull(tokenResponse);
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenResponse.token);
            // Create a New chat thread
            var chatThread = _client.PostAsJsonAsync("/chat/threads", new CreateChatThreadRequest("Test Topic", new List<ChatParticipant>())).Result;
            Assert.IsNotNull(chatThread);
            var chatThreadInfo = chatThread.Content.ReadFromJsonAsync<ChatThreadCreation>().Result;
            Assert.IsNotNull(chatThreadInfo);
            _chatThreadCreationInfo = chatThreadInfo.ChatThread;
        }

        [TestMethod()]
        public void AddChatThreadEndpointsTest()
        {
            var identity2 = _client.PostAsJsonAsync("/identities/", new CreateIdentityRequest([IdentityTokenScope.Chat])).Result;
            // Get everything right of /identities/ prefix from the location
            var identity2Str = identity2.Headers.Location?.ToString().Split("/identities/")[1];
            Assert.IsNotNull(identity2Str);

            var participant2 = new ChatParticipant(
                new CommunicationIdentifier(identity2Str), "John Doe", DateTimeOffset.UtcNow);

            // Call add participant to chat thread
            var addParticipant = _client.PostAsJsonAsync($"/chat/threads/{_chatThreadCreationInfo.Id}/participants/:add",
                                  new AddChatParticipantsRequest([participant2])).Result;
            Assert.AreEqual(System.Net.HttpStatusCode.Created, addParticipant.StatusCode);
            // Get Participants

            var getParticipants = _client.GetFromJsonAsync<ChatParticipantsInfo>($"/chat/threads/{_chatThreadCreationInfo.Id}/participants").Result;
            Assert.IsNotNull(getParticipants);
            // Assert there is 2 participants:
            Assert.IsTrue(getParticipants.Value.Count == 2);
            // Assert any of the participants is the one we added
            Assert.IsTrue(getParticipants.Value.Any(x => x.CommunicationIdentifier.RawId == identity2Str));


            // Sends a Message
            var message = _client.PostAsJsonAsync($"/chat/threads/{_chatThreadCreationInfo.Id}/messages",
                               new SendChatMessageRequest("Hello World", "John Doe", ChatMessageType.Text)).Result;
            Assert.AreEqual(System.Net.HttpStatusCode.Created, message.StatusCode);

            // Get Messages
            //var getMessages = _client.GetFromJsonAsync<ChatMessagesResponse>($"/chat/threads/{_chatThreadCreationInfo.Id}/messages").Result;
            var getMessages = _client.GetStringAsync($"/chat/threads/{_chatThreadCreationInfo.Id}/messages").Result;
            Assert.IsNotNull(getMessages);
            Console.WriteLine(getMessages);



        }
    }
}