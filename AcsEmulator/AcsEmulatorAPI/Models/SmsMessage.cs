#nullable disable

namespace AcsEmulatorAPI.Models
{
    public class SmsMessage
    {
        public string Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Message { get; set; }

        public bool EnableDeliveryReport { get; set; } = false;

        public string Tag { get; set; }

        public static SmsMessage CreateNew(string from, string to, string message)
        {
            return new SmsMessage
            {
                Id = Guid.NewGuid().ToString(),
                From = from,
                To = to,
                Message = message
            };
        }
    }
}
