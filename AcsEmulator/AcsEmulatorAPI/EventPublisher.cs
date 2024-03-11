// Deprecated package, but works with EventGridSimulator.
// TODO: Investigate why Azure.Messaging.EventGrid doesn't work.
using Azure;
using Azure.Messaging.EventGrid;
using System.Text;

namespace AcsEmulatorAPI
{
    public class EventPublisher
    {
        private readonly string _simulatorSystemTopicHostname;
        private readonly bool _doEvents;

        private EventGridPublisherClient _eventGridClient;

        public EventPublisher(string simulatorSystemTopicHostname, string simulatorSystemTopicCredentials)
        {
            _simulatorSystemTopicHostname = simulatorSystemTopicHostname;

            _doEvents = !string.IsNullOrEmpty(simulatorSystemTopicHostname) && !string.IsNullOrEmpty(simulatorSystemTopicCredentials);

            if (_doEvents)
            {
                _eventGridClient = new EventGridPublisherClient(new System.Uri(simulatorSystemTopicHostname), new AzureKeyCredential("TheLocal+DevelopmentKey="));
            }
        }

        public async Task SendSmsDeliveryReport(string from, string to, string tag)
        {
            if (!_doEvents) return;

            await _eventGridClient.SendEventAsync(
                    new EventGridEvent(subject: $"/phonenumber/{from}", eventType: "Microsoft.Communication.SMSDeliveryReportReceived", dataVersion: "1.0",
                        data: new SmsDeliveryReport(
                            Guid.NewGuid().ToString(),
                            from,
                            to,
                            "Delivered",
                            "2000: Message Delivered Successfully",
                            DateTime.UtcNow,
                            //deliveryAttempts: [Array],
                            tag)));
        }

        public async Task SendSmsReceivedEvent(string from, string to, string message)
        {
            if (!_doEvents) return;

            await _eventGridClient.SendEventAsync(
                    new EventGridEvent(subject: $"/phonenumber/{to}", eventType: "Microsoft.Communication.SMSReceived", dataVersion: "1.0",
                        data: new SmsReceivedEvent(
                            Guid.NewGuid().ToString(),
                            from,
                            to,
                            message,
                            DateTime.UtcNow)));
        }

        public async Task SendIncomingCallEvent(string fromPstn, string toPstn)
        {
            if (!_doEvents) return;

            await _eventGridClient.SendEventAsync(
                    new EventGridEvent(subject: $"/caller/4:{fromPstn}/recipient/4:{toPstn}", eventType: "Microsoft.Communication.IncomingCall", dataVersion: "1.0",
                        data: new IncomingCallEvent(
                            to: new PhoneNumberIdentifier($"4:{toPstn}", new PhoneNumberValue(toPstn)),
                            from: new PhoneNumberIdentifier($"4:{fromPstn}", new PhoneNumberValue(fromPstn)),
                            serverCallId: NewRandomBase64(),
                            incomingCallContext: NewRandomBase64())));
        }

        record SmsDeliveryReport(
            string messageId,
            string from,
            string to,
            string deliveryStatus,
            string deliveryStatusDetails,
            DateTime receivedTimeStamp,
            string tag);

        record SmsReceivedEvent(
            string messageId,
            string from,
            string to,
            string message,
            DateTime receivedTimeStamp);

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

        private static string NewRandomBase64() => Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()));
    }
}
