using Azure.Messaging.EventGrid;
using Humanizer;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcsEmulatorAPI.Endpoints.CallAutomation
{
    record IncomingCallEvent(
        PhoneNumberIdentifier to,
        PhoneNumberIdentifier from,
        string serverCallId,
        string incomingCallContext
        );

    record PhoneNumberIdentifier(
        string rawId,
        PhoneNumberValue phoneNumber,
        string kind = "phoneNumber"
        );
    record PhoneNumberValue(
        string value);

    public static class CallAutomationEvents
    {
        private static string NewRandomBase64() => Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()));

        public static EventGridEvent IncomingCallEvent(string fromPstn, string toPstn)
        {
            return new EventGridEvent(subject: $"/caller/4:{fromPstn}/recipient/4:{toPstn}",
                    eventType: "Microsoft.Communication.IncomingCall", dataVersion: "1.0",
                    data: new IncomingCallEvent(
                        to: new PhoneNumberIdentifier($"4:{toPstn}", new PhoneNumberValue(toPstn)),
                        from: new PhoneNumberIdentifier($"4:{fromPstn}", new PhoneNumberValue(fromPstn)),
                        serverCallId: NewRandomBase64(),
                        incomingCallContext: NewRandomBase64()));
        }

    }
}
