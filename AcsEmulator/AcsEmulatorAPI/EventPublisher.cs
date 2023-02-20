// Deprecated package, but works with EventGridSimulator.
// TODO: Investigate why Azure.Messaging.EventGrid doesn't work.
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;

namespace AcsEmulatorAPI
{
    public class EventPublisher
    {
        private readonly string _simulatorSystemTopicHostname;
        private readonly bool _doEvents;

        private EventGridClient _eventGridClient;

        public EventPublisher(string simulatorSystemTopicHostname, string simulatorSystemTopicCredentials)
        {
            _simulatorSystemTopicHostname = simulatorSystemTopicHostname;

            _doEvents = !string.IsNullOrEmpty(simulatorSystemTopicHostname) && !string.IsNullOrEmpty(simulatorSystemTopicCredentials);

            if (_doEvents)
            {
                _eventGridClient = new EventGridClient(new TopicCredentials("TheLocal+DevelopmentKey="));
            }
        }

        public async Task SendSmsDeliveryReport(string from, string to, string tag)
        {
            if (!_doEvents) return;

            await _eventGridClient.PublishEventsWithHttpMessagesAsync(
                topicHostname: _simulatorSystemTopicHostname,
                events: new List<EventGridEvent>
                {
                    new EventGridEvent
                    {
                        Id = Guid.NewGuid().ToString(),
                        //Topic = "/subscriptions/<my-sub-id>/resourceGroups/<my-rg-name>/providers/microsoft.communication/communicationservices/<my-resource-name>",
                        Subject = $"/phonenumber/{from}",
                        Data = new SmsDeliveryReport(
                            Guid.NewGuid().ToString(),
                            from,
                            to,
                            "Delivered",
                            "2000: Message Delivered Successfully",
                            DateTime.UtcNow,
                            //deliveryAttempts: [Array],
                            tag),
                        EventType = "Microsoft.Communication.SMSDeliveryReportReceived",
                        DataVersion = "1.0",
                        EventTime = DateTime.UtcNow
                    }
                });
        }

        public async Task SendSmsReceivedEvent(string from, string to, string message)
        {
            if (!_doEvents) return;

            await _eventGridClient.PublishEventsWithHttpMessagesAsync(
                topicHostname: _simulatorSystemTopicHostname,
                events: new List<EventGridEvent>
                {
                    new EventGridEvent
                    {
                        Id = Guid.NewGuid().ToString(),
                        Subject = $"/phonenumber/{to}", // indeed "to" here, because we are sending the SMS to the _ACS_ number
                        Data = new SmsReceivedEvent(
                            Guid.NewGuid().ToString(),
                            from,
                            to,
                            message,
                            DateTime.UtcNow),
                        EventType = "Microsoft.Communication.SMSReceived",
                        DataVersion = "1.0",
                        EventTime = DateTime.UtcNow
                    }
                });
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
    }
}
