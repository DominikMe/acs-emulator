using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace AcsEmulatorAPI
{
    public class CallAutomationWebSockets
	{
		private Dictionary<string, WebSocket> _sockets = new();

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

            app.MapPost("/admin/callAutomation:raiseIncomingCallEvent", async (RaiseIncomingCallEvent req, EventPublisher eventPublisher, ILogger<Program> log) =>
            {
                try
                {
                    await eventPublisher.SendIncomingCallEvent(req.From, req.To);
                }
                catch (Exception e)
                {
                    log.LogError(e, "Failed to raise IncomingCall event");
                }

                return Results.Ok();
            });
        }

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
            Console.WriteLine("Failed to get active websocket for " + phoneNumber);
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
				Console.WriteLine($"{phoneNumber} sent: {received}");

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
}
