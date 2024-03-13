using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AcsEmulatorAPI.Models
{
    public record CreateCallRequest(
        string CallbackUri,
        List<CommunicationIdentifier> Targets,
        CallIntelligenceOptions? CallIntelligenceOptions,
        string? OperationContext,
        CommunicationUser Source,
        PhoneNumber? SourceCallerIdNumber,
        string? SourceDisplayName
    );

    public record CallIntelligenceOptions(string CognitiveServicesEndpoint);

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CallConnectionState
    {
        [EnumMember(Value = "connected")]
        Connected,
        [EnumMember(Value = "connecting")]
        Connecting,
        [EnumMember(Value = "disconnected")]
        Disconnected,
        [EnumMember(Value = "disconnecting")]
        Disconnecting,
        [EnumMember(Value = "transferAccepted")]
        TransferAccepted,
        [EnumMember(Value = "transferring")]
        Transferring,
        [EnumMember(Value = "unknown")]
        Unknown
    }
}
