using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcsEmulatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly string _authToken;

        public ChatControllerTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
            // If Identity Unit tests is passing, below code will work
            var identity = _client.PostAsJsonAsync("/identities/", new CreateIdentityRequest([IdentityTokenScope.Chat])).Result;
            var token = _client.PostAsJsonAsync(identity.Headers.Location + "/:issueAccessToken", new IssueTokenRequest([IdentityTokenScope.Chat], 60)).Result;
            var tokenResponse = token.Content.ReadFromJsonAsync<IdentityTokenResponse>().Result;
            Assert.IsNotNull(tokenResponse);
            _authToken = tokenResponse.token;    
        }

        [TestMethod()]
        public void AddChatEndpointsTest()
        {
            // Check if the /chat/threads endpoint is protected
            var response = _client.PostAsJsonAsync("/chat/threads", new CreateChatThreadRequest("Test Topic", new List<ChatParticipant>())).Result;
            Assert.AreEqual(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);

            // Add default Authorize header
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authToken);

            // Create a New chat thread
            response = _client.PostAsJsonAsync("/chat/threads", new CreateChatThreadRequest("Test Topic", new List<ChatParticipant>())).Result;
            Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);

            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            var chatThreadCreation = response.Content.ReadFromJsonAsync<ChatThreadCreation>().Result;
            Assert.IsNotNull(chatThreadCreation);
            var chatThreadInfo = chatThreadCreation.ChatThread;
            // id must start with 19:
            Assert.IsTrue(chatThreadInfo.Id.StartsWith("19:"));
            Assert.AreEqual("Test Topic", chatThreadInfo.Topic);


            // Call Get /chat/threads
            var chatThreads = _client.GetFromJsonAsync<ChatThreadInfo>("/chat/threads").Result;
            Assert.IsNotNull(chatThreads);
            var firstChatThread = chatThreads.Value.First();
            Assert.AreEqual(chatThreadInfo.Id, firstChatThread.Id);
            Assert.AreEqual(chatThreadInfo.Topic, firstChatThread.Topic);

            // Call Get /chat/threads/{chatThreadInfo.Id}
            var chatThread = _client.GetFromJsonAsync<ChatThreadCreationInfo>($"/chat/threads/{chatThreadInfo.Id}").Result;
            Assert.IsNotNull(chatThread);
            Assert.AreEqual(chatThreadInfo.Id, chatThread.Id);

            // Test the Get on admin chat endpoint
            var adminChatThreads = _client.GetFromJsonAsync<ChatThreadInfo>("/admin/chat/threads").Result;
            Assert.IsNotNull(adminChatThreads);
            // Admin chat thread can show more info depending on DB, look for the specific Id
            Assert.IsTrue(adminChatThreads.Value.Any(x => x.Id == chatThreadInfo.Id));
        }
    }
}