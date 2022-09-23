using System.Net.WebSockets;

namespace AcsEmulatorAPI
{
	public class Trouter
	{
		public Trouter(WebApplication app)
		{
			app.MapGet("/trouter/v4/a", (HttpContext context) =>
			new {
				ccid = "Q0du9A4hdNg",
				id = "wnwabJ7wc06Q0du9A4hdNg",
				socketio= $"{context.Request.PathBase}/ws",
				surl = "https://trouter-azsc-uswe-0-b.trouter.skype.com:3443/v4/f/wnwabJ7wc06Q0du9A4hdNg/",
				url = "https://trouter-azsc-uswe-0-b.trouter.skype.com:8443/v4/f/wnwabJ7wc06Q0du9A4hdNg/",
				ttl = "585731",
				healthUrl = "https://go.trouter.skype.com:443/v4/h",
				curlb = "https://trouter-azsc-uswe-0-b.trouter.skype.com:443",
				connectparams = new {
					sr = "OksAAPsgwnwabJ7wc06Q0du9A4hdNlMRzPQpZlCmwGsHpVXscO1rsy1sAn9Ned4hda9KzxgO_f4apN39B4NkRaaa6pGHLp-iirXMEQl67LLZrnVluPo",
					issuer = "prod-2",
					sp = "connect",
					se = "1664546360809",
					st = "1663960329809",
					sig = "3uVO50vXZxfQFek9pUr5f2INH6N_tNff-vpCN66c9bs"
				}
			});

			app.MapGet("/ws", async (HttpContext context) =>
			{
				if (!context.WebSockets.IsWebSocketRequest)
					return Results.BadRequest();

				using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
				await Echo(webSocket);

				return Results.Ok();
			});
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
