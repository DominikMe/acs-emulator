using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AcsEmulatorAPI.Models
{
    public record CreateCallRequest(
        string CallbackUri,
        List<CommunicationIdentifier> Targets,
        CallIntelligenceOptions? CallIntelligenceOptions = null,
        string? OperationContext = null,
        CommunicationUser? Source = null,
        PhoneNumber? SourceCallerIdNumber = null,
        string? SourceDisplayName = null
    );

    public record CallIntelligenceOptions(string CognitiveServicesEndpoint);

    public record CallConnectionCreation(CallConnectionProperties CallConnectionProperties);

    public record CallConnectionProperties(
        Guid CallConnectionId,
        string CallbackUri,
        List<CommunicationIdentifier> Targets,
        CallConnectionState CallConnectionState,
        string? AnsweredBy,
        string? CorrelationId,
        string? ServerCallId,
        string? Source,
        string? SourceCallerIdNumber,
        string? SourceDisplayName
    );

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
