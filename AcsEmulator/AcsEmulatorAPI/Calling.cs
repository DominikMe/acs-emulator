using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace AcsEmulatorAPI
{
	public static class CallingServices
	{
		public static void AddCalling(this WebApplication app)
		{
            string baseUrl = "";
            var convId = NewRandomBase64();

            // couldn't make it work with string.Format and I wanted to keep the verbatim string instead of new {} anonymous objects for easier manipulation
			app.MapPost("/calling/cpconv", [Authorize] (ClaimsPrincipal principal) => Results.Created("/conv/someId", JsonSerializer.Deserialize<dynamic>("""
            {
              "conversationController": "{0}/conv/{1}?i=82&e=638031906907199622",
              "sequenceNumber": 2,
              "subject": "",
              "activeModalities": {
                "threadlessGroup": {
                  "id": "0ff23200-653b-11ed-9484-fdc9fb5865ae"
                }
              },
              "state": {
                "isMultiParty": true,
                "groupCallInitiator": "{2}",
                "isHostless": true,
                "conversationType": "groupCall",
                "isBroadcast": false,
                "isMeetingActivated": false
              },
              "links": {
                "leave": "{0}/conv/{1}/leave?i=82&e=638031906907199622",
                "addParticipant": "{0}/conv/{1}/addParticipant?i=82&e=638031906907199622",
                "removeParticipant": "{0}/conv/{1}/removeParticipant?i=82&e=638031906907199622",
                "addModality": "{0}/conv/{1}/addModality?i=82&e=638031906907199622",
                "addParticipantAndModality": "{0}/conv/{1}/add?i=82&e=638031906907199622",
                "removeModality": "{0}/conv/{1}/removeModality?i=82&e=638031906907199622",
                "mute": "{0}/conv/{1}/mute?i=82&e=638031906907199622",
                "unmute": "{0}/conv/{1}/unmute?i=82&e=638031906907199622",
                "notificationLinks": "{0}/conv/{1}/notificationLinks?i=82&e=638031906907199622",
                "merge": "{0}/conv/{1}/merge?i=82&e=638031906907199622",
                "updateEndpointMetadata": "{0}/conv/{1}/updateEndpointMetadata?i=82&e=638031906907199622",
                "updateEndpointState": "{0}/conv/{1}/updateEndpointState?i=82&e=638031906907199622",
                "admit": "{0}/conv/{1}/admit?i=82&e=638031906907199622",
                "subscribe": "{0}/subscribe/edea5ac7-d81b-4690-929c-871cbd37522e/0?i=20",
                "brokerHttpTransport": "http://52.114.142.115/enc",
                "conversationHttpTransport": "http://40.78.10.104/enc",
                "publishState": "{0}/conv/{1}/publishState?i=82&e=638031906907199622",
                "removeState": "{0}/conv/{1}/removeState?i=82&e=638031906907199622",
                "updateMeetingSettings": "{0}/conv/{1}/updateMeetingSettings?i=82&e=638031906907199622",
                "searchParticipants": "{0}/conv/{1}/searchParticipants?i=82&e=638031906907199622",
                "getAllParticipants": "{0}/conv/{1}/getAllParticipants?i=82&e=638031906907199622",
                "admitAll": "{0}/conv/{1}/admitAll?i=82&e=638031906907199622",
                "updateParticipantMapping": "{0}/conv/{1}/updateParticipantMapping?i=82&e=638031906907199622",
                "sendMessage": "{0}/conv/{1}/sendMessage?i=82&e=638031906907199622"
              },
              "callLimits": {
                "remainingDurationInMinutes": 60,
                "maxAllowedParticipants": 100,
                "sponsor": "",
                "enforcePaywallLimits": false
              },
              "streamingSetupFailureDebugInfo": null
            }
            """
            .Replace("{0}", baseUrl)
            .Replace("{1}", convId)
            .Replace("{2}", GetRawId(principal)))));

			// get mediacontent blob
            // somehow send down a base64 encoded answer(?) via Trouter
			app.MapPost("/calling/renegotiate", () => Results.Accepted());

			app.MapPost("/calling/acknowledge", () => Results.Accepted());

			app.MapPost("/calling/updateEndpointState", () => Results.Ok());

            // send back down via Trouter
			app.MapPost("/calling/controlVideoStreaming", () => Results.Accepted());
		}

		private static string NewRandomBase64() => Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()));

        private static string GetRawId(ClaimsPrincipal principal) => principal.Claims.First(x => x.Type == "skypeid").Value;
	}
}
