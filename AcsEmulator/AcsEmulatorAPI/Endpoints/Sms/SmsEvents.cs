using Azure;
using Azure.Messaging.EventGrid;
using Humanizer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcsEmulatorAPI.Endpoints.Sms
{
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

    public static class SmsEvents
    {
        public static EventGridEvent SmsDeliveryReport(string from, string to, string tag)
        {
            return new EventGridEvent(subject: $"/phonenumber/{from}", eventType: "Microsoft.Communication.SMSDeliveryReportReceived", dataVersion: "1.0",
                        data: new SmsDeliveryReport(
                            Guid.NewGuid().ToString(),
                            from,
                            to,
                            "Delivered",
                            "2000: Message Delivered Successfully",
                            DateTime.UtcNow,
                            //deliveryAttempts: [Array],
                            tag));
        }

        public static EventGridEvent SmsReceivedEvent(string from, string to, string message)
        {
            return new EventGridEvent(subject: $"/phonenumber/{to}", eventType: "Microsoft.Communication.SMSReceived", dataVersion: "1.0",
                        data: new SmsReceivedEvent(
                            Guid.NewGuid().ToString(),
                            from,
                            to,
                            message,
                            DateTime.UtcNow));
        }
    }
}
