using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Text;
using System.Xml.Linq;

namespace AcsEmulatorAPI
{
	public class Trouter
	{
		private Dictionary<string, string> _srToSkypeId = new();
		private Dictionary<string, string> _socketIdToSkypeId = new();
		private Dictionary<string, List<WebSocket>> _skypeIdToSockets = new();

		public Trouter(WebApplication app)
		{
			// uses x-skypetoken header, not auth header
			app.MapPost("/v4/a", dynamic ([FromHeader(Name = "x-skypetoken")] string skypeTokenHeader) => {
				var token = ValidateToken(skypeTokenHeader, app.Configuration["jwtSigningKey"]);
				if (token is null)
					return Results.Unauthorized();

				var sessionId = Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()));
				var sr = Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()));
				_srToSkypeId[sr] = token.Claims.First(x => x.Type == "skypeid").Value;

				return new
				{
					ccid = "Q0du9A4hdNg",
					id = sessionId,
					socketio = $"https://localhost/trouter/",
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
						se = DateTimeOffset.UtcNow.AddDays(7).ToUnixTimeSeconds().ToString(),
						st = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
						sig = Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()))
					}
				};
			});

			app.MapGet("/socket.io/1", (HttpRequest request, HttpResponse response, string sr) => {
				var skypeId = _srToSkypeId[sr];
				var socketId = Guid.NewGuid().ToString();
				_socketIdToSkypeId[socketId] = skypeId;
				response.Headers["Access-Control-Allow-Origin"] = request.Headers["origin"];
				return $"{socketId}:70:70:websocket,xhr-polling,jsonp-polling";
			});

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

				await Echo(webSocket);

				return Results.Ok();
			});

			app.MapGet("/trouter/h", () => Results.Ok());

			app.MapGet("/trouter/f/{sessionId}", () => Results.Ok());
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

		private static async Task Echo(WebSocket webSocket)
		{
			var buffer = new byte[1024 * 4];
			var receiveResult = await webSocket.ReceiveAsync(
				new ArraySegment<byte>(buffer), CancellationToken.None);

			while (!receiveResult.CloseStatus.HasValue)
			{
				await webSocket.SendAsync(
					new ArraySegment<byte>(buffer, 0, receiveResult.Count),
					receiveResult.MessageType,
					receiveResult.EndOfMessage,
					CancellationToken.None);

				receiveResult = await webSocket.ReceiveAsync(
					new ArraySegment<byte>(buffer), CancellationToken.None);
			}

			await webSocket.CloseAsync(
				receiveResult.CloseStatus.Value,
				receiveResult.CloseStatusDescription,
				CancellationToken.None);
		}
	}
}
