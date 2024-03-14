using AcsEmulatorAPI.Contracts.Services;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace AcsEmulatorAPI.Endpoints.CallAutomation
{
    public class CallAutomationWebSockets
    {
        private Dictionary<string, WebSocket> _sockets = new();
        private readonly ILogger<Program> _logger;

        public event EventHandler<IncomingMessageEventArgs> OnIncomingMessage;

        public CallAutomationWebSockets(ILogger<Program> logger)
        {
            this._logger = logger;
        }

        public void AddEndpoints(WebApplication app)
        {
            app.MapGet("/admin/callAutomation/sockets/{phoneNumber}", async (HttpContext context, string phoneNumber) =>
            {
                if (!context.WebSockets.IsWebSocketRequest)
                    return Results.BadRequest();

                using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                _sockets.Add(phoneNumber, webSocket);

                await Listen(webSocket, phoneNumber);
                _sockets.Remove(phoneNumber);

                return Results.Ok();
            }).RequireCors("websocketPolicy");

            app.MapPost("/admin/callAutomation:raiseIncomingCallEvent", async (RaiseIncomingCallEvent req, IEventPublishingService eventPublisher) =>
            {
                try
                {
                    await eventPublisher.SendEvent(CallAutomationEvents.IncomingCallEvent(req.From, req.To));
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Failed to raise IncomingCall event");
                }

                return Results.Ok();
            });
        }

        public async Task MakePhoneCall(string phoneNumber, string callerId, string callerDisplayName) => await SendMessage(phoneNumber, callerId, JsonSerializer.Serialize(
                    new
                    {
                        action = "incomingCall",
                        time = DateTimeOffset.UtcNow.ToString("o"),
                        callerId,
                        callerDisplayName
                    }
                ));

        public async Task AnswerPhoneCall(string phoneNumber, string callerId) => await SendMessage(phoneNumber, callerId, JsonSerializer.Serialize(
                    new
                    {
                        action = "answer",
                        time = DateTimeOffset.UtcNow.ToString("o"),
                        callerId,
                    }
                ));

        public async Task PlayText(string phoneNumber, string callerId, string text) => await SendMessage(phoneNumber, callerId, JsonSerializer.Serialize(
                    new
                    {
                        action = "playText",
                        time = DateTimeOffset.UtcNow.ToString("o"),
                        callerId,
                        text
                    }
                ));

        private async Task SendMessage(string phoneNumber, string callerId, string message)
        {
            if (_sockets.TryGetValue(phoneNumber, out var socket))
            {
                await SendMessage(socket, message);
            }
            _logger.LogError("Failed to get active websocket for " + phoneNumber);
        }

        private static Task SendMessage(WebSocket webSocket, string message)
            => webSocket.SendAsync(
                    Encoding.UTF8.GetBytes(message),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None);

        private async Task Listen(WebSocket webSocket, string phoneNumber)
        {
            var buffer = new byte[1024 * 4];
            var receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!receiveResult.CloseStatus.HasValue)
            {
                var received = Encoding.UTF8.GetString(buffer);

                // todo: handle
                _logger.LogInformation($"{phoneNumber} sent: {received}");

                var message = JsonSerializer.Deserialize<IncomingMessage>(received);

                OnIncomingMessage?.Invoke(this, new IncomingMessageEventArgs(phoneNumber, message));

                Array.Clear(buffer, 0, buffer.Length);
                receiveResult = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await webSocket.CloseAsync(
                receiveResult.CloseStatus.Value,
                receiveResult.CloseStatusDescription,
                CancellationToken.None);
        }
    }

    record RaiseIncomingCallEvent(string From, string To);

    record IncomingMessage(string action, string content);

    public class IncomingMessageEventArgs : EventArgs
    {
        internal IncomingMessageEventArgs(string from, IncomingMessage incomingMessage)
        {
            From = from;
            Action = incomingMessage.action;
            Content = incomingMessage.content;
        }

        public string From { get; set; }
        public string Action { get; set; }
        public string Content { get; set; }
    }
}
