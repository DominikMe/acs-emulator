using AcsEmulatorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace AcsEmulatorAPI
{
	public class Trouter
	{
		private Dictionary<string, string> _srToSkypeId = new();
		private Dictionary<string, string> _socketIdToSkypeId = new();
		private Dictionary<string, List<WebSocket>> _skypeIdToSockets = new();

		public void AddEndpoints(WebApplication app)
		{
			// uses x-skypetoken header, not auth header
			app.MapPost("/v4/a", dynamic ([FromHeader(Name = "x-skypetoken")] string skypeTokenHeader) => {
				var token = ValidateToken(skypeTokenHeader, app.Configuration["JwtSigningKey"]);
				if (token is null)
					return Results.Unauthorized();

				var sessionId = NewRandomBase64();
				var sr = NewRandomBase64();
				_srToSkypeId[sr] = token.Claims.First(x => x.Type == "skypeid").Value;

				return new
				{
					ccid = "Q0du9A4hdNg",
					id = sessionId,
					socketio = $"https://localhost",
					surl = $"https://localhost/trouter/f/{sessionId}/",
					url = $"https://localhost/trouter/f/{sessionId}/",
					ttl = "585731",
					healthUrl = $"https://localhost/trouter/h",
					curlb = "https://trouter-azsc-uswe-0-b.trouter.skype.com:443",
					connectparams = new
					{
						sr = sr,
						issuer = "prod-2",
						sp = "connect",
						se = DateTimeOffset.UtcNow.AddDays(7).ToUnixTimeMilliseconds().ToString(),
						st = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(),
						sig = NewRandomBase64()
					}
				};
			});

			app.MapGet("/socket.io/1", (HttpRequest request, HttpResponse response, string sr) => {
				if (_srToSkypeId.TryGetValue(sr, out var skypeId))
				{
					var socketId = Guid.NewGuid().ToString();
					_socketIdToSkypeId[socketId] = skypeId;
					return Results.Ok($"{socketId}:70:70:websocket");
				}
				return Results.Problem();
			}).RequireCors("trouterPolicy");

			app.MapGet("/socket.io/1/websocket/{socketId}", async (HttpContext context, string socketId) =>
			{
				if (!context.WebSockets.IsWebSocketRequest)
					return Results.BadRequest();

				using var webSocket = await context.WebSockets.AcceptWebSocketAsync();

				var skypeId = _socketIdToSkypeId[socketId];
				if (_skypeIdToSockets.TryGetValue(skypeId, out var sockets))
				{
					sockets.Add(webSocket);
				}
				else
				{
					_skypeIdToSockets[skypeId] = new List<WebSocket> { webSocket };
				}

				await SendTrouterConnected(webSocket);
				await Ack(webSocket);
				_skypeIdToSockets[skypeId].Remove(webSocket);

				return Results.Ok();
			}).RequireCors("trouterPolicy");

			app.MapGet("/trouter/h", () => Results.Ok());

			app.MapGet("/trouter/f/{sessionId}", () => Results.Ok());
		}

		public async Task SendChatMessageReceived(string receiverRawId, string threadId, ChatMessage message)
		{
			if(_skypeIdToSockets.TryGetValue(receiverRawId, out var sockets))
			{
				foreach (var socket in sockets)
				{
					await SendMessage(socket, "3:::" + JsonSerializer.Serialize(
						new
						{
							id = Random.Shared.NextInt64(),
							method = "POST",
							url = "/trouter/f/" + NewRandomBase64(),
							headers = new {},
							body = JsonSerializer.Serialize(new
							{
								eventId = 200,
								senderId = message.Sender.RawId,
								recipientId = receiverRawId.Split("8:")[1],
								recipientMri = receiverRawId,
								transactionId = NewRandomBase64(),
								groupId = threadId,
								messageId = message.Id,
								collapseId = NewRandomBase64(),
								messageType = message.Type.ToString(),
								messageBody = message.Content,
								senderDisplayName = message.SenderDisplayName,
								clientMessageId = "",
								originalArrivalTime = message.CreatedOn.ToString("o"),
								priority = "",
								version = message.Id, // todo: support message edits
								acsChatMessageData = new
								{
									fileSharingMetadata = new object[] {}
								}
							})
						}
					));
				}
			}
			Console.WriteLine("Failed to get active websocket for " + receiverRawId);
		}

		public async Task SendTyping(string senderRawId, string? senderDisplayName, string receiverRawId, string threadId, string messageId)
		{
			if (_skypeIdToSockets.TryGetValue(receiverRawId, out var sockets))
			{
				foreach (var socket in sockets)
				{
					await SendMessage(socket, "3:::" + JsonSerializer.Serialize(
						new
						{
							id = Random.Shared.NextInt64(),
							method = "POST",
							url = "/trouter/f/" + NewRandomBase64(),
							headers = new { },
							body = JsonSerializer.Serialize(new
							{
								eventId = 245,
								senderId = senderRawId,
								recipientId = receiverRawId.Split("8:")[1],
								recipientMri = receiverRawId,
								transactionId = NewRandomBase64(),
								groupId = threadId,
								messageId = messageId,
								collapseId = NewRandomBase64(),
								messageType = "Control/Typing",
								senderDisplayName = senderDisplayName ?? "",
								originalArrivalTime = DateTimeOffset.UtcNow.ToString("o"),
								version = messageId
							})
						}
					));
				}
			}
			Console.WriteLine("Failed to get active websocket for " + receiverRawId);
		}

		private JwtSecurityToken? ValidateToken(string token, string jwtSigningKey)
		{
			if (string.IsNullOrEmpty(token))
				return null;

			var tokenHandler = new JwtSecurityTokenHandler();
			try
			{
				tokenHandler.ValidateToken(token, UserToken.GetTokenValidationParameters(jwtSigningKey), out SecurityToken validatedToken);
				return (JwtSecurityToken)validatedToken;
			}
			catch
			{
				return null;
			}
		}

		private static async Task SendTrouterConnected(WebSocket webSocket)
		{
			await SendMessage(webSocket, "1::");
			await SendMessage(webSocket, $"5:1::{JsonSerializer.Serialize(new { name = "trouter.connected", args = new[] { new { ttl = 570883, dur = "260" } } })}");
			await SendMessage(webSocket, $"5:2::{JsonSerializer.Serialize(new { name = "trouter.message_loss", args = new[] { new { droppedIndicators = new[] { new { tag = "", etag = DateTimeOffset.UtcNow.ToString("o") } } } } })}");
		}

		private static Task SendMessage(WebSocket webSocket, string message)
			=> webSocket.SendAsync(
					Encoding.UTF8.GetBytes(message),
					WebSocketMessageType.Text,
					true,
					CancellationToken.None);

		private async Task Ack(WebSocket webSocket)
		{
			var buffer = new byte[1024 * 4];
			var receiveResult = await webSocket.ReceiveAsync(
				new ArraySegment<byte>(buffer), CancellationToken.None);

			while (!receiveResult.CloseStatus.HasValue)
			{
				var received = Encoding.UTF8.GetString(buffer);
				var segments = received.Split("::");
				if (segments[0].StartsWith("5:"))
				{
					var seq = segments[0].Split(":")[1];
					if (segments[1].StartsWith(@"{""name"":""ping""}"))
					{
						await SendMessage(webSocket, $"6:::{seq}[\"pong\"]");
					}
					else
					{
						await SendMessage(webSocket, $"6:::{seq}[]");
					}
				}

				Array.Clear(buffer, 0, buffer.Length);
				receiveResult = await webSocket.ReceiveAsync(
					new ArraySegment<byte>(buffer), CancellationToken.None);
			}

			await webSocket.CloseAsync(
				receiveResult.CloseStatus.Value,
				receiveResult.CloseStatusDescription,
				CancellationToken.None);
		}

		private string NewRandomBase64() => Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()));
	}
}
