namespace AcsEmulatorAPI.Models
{
    public class CommunicationIdentifier
    {
        public CommunicationIdentifier(string rawId) => RawId = rawId;

        public string RawId { get; set; }

        // todo: support multiple identifier types
        public CommunicationUser CommunicationUser => new(RawId);

        public PhoneNumber PhoneNumber { get; set; }
    }

    public record CommunicationUser(string Id);
    public record PhoneNumber(string Value);
}
