using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AcsEmulatorAPI.Models
{
    public class CommunicationIdentifier
    {

        public CommunicationIdentifier()
        { }

        public CommunicationIdentifier(string rawId)
        {
            CommunicationUser = new(rawId);
            Kind = CommunicationIdentifierKind.CommunicationUser;
            RawId = rawId;
        }

        public CommunicationIdentifier(PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
            Kind = CommunicationIdentifierKind.PhoneNumber;
            RawId = $"4:{phoneNumber.Value}";
        }

        public CommunicationIdentifierKind Kind { get; set; } = CommunicationIdentifierKind.Unknown;

        public string? RawId { get; set; }

        public CommunicationUser? CommunicationUser { get; set; }

        public PhoneNumber? PhoneNumber {  get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CommunicationIdentifierKind
    {
        [EnumMember(Value = "communicationUser")]
        CommunicationUser,
        [EnumMember(Value = "phoneNumber")]
        PhoneNumber,
        [EnumMember(Value = "unknown")]
        Unknown
    }

    public record CommunicationUser(string Id);

    public record PhoneNumber(string Value);
}
