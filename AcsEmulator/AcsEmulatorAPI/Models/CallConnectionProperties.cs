#nullable disable

namespace AcsEmulatorAPI.Models
{
    public class CallConnectionProperties
    {
        public CommunicationUser AnsweredBy { get; set; }
        public string CallConnectionId { get; set; }
        public string CallbackUri { get; set; }
    }
}