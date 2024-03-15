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
        string? SourceDisplayName = null);

    public record CallIntelligenceOptions(string CognitiveServicesEndpoint);

    public record CallConnectionProperties(
        Guid CallConnectionId,
        string CallbackUri,
        List<CommunicationIdentifier> Targets,
        CallConnectionState CallConnectionState,
        CommunicationUser? AnsweredBy,
        string? CorrelationId,
        string? ServerCallId,
        CommunicationIdentifier? Source,
        PhoneNumber? SourceCallerIdNumber,
        string? SourceDisplayName);

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

    public record PlayRequest(
        List<PlaySource> playSources,
        CommunicationIdentifier playTo,
        PlayOptions playOptions,
        string operationContext,
        string operationCallbackUri);

    public record PlaySource(
        PlaySourceType kind,
        string playSourceCacheId,
        FileSource? file,
        TextSource? text,
        SsmlSource? ssml);

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PlaySourceType
    {
        [EnumMember(Value = "file")]
        File,
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "ssml")]
        Ssml,
    }

    public record FileSource(string uri);

    public record TextSource(
        string text,
        string sourceLocale,
        string voiceKind,
        string voiceName,
        string customVoiceEndpointId);

    public record SsmlSource(
        string ssmlText,
        string customVoiceEndpointId);

    public record PlayOptions(bool loop);

    public record RecognizeRequest(
        RecognizeInputType recognizeInputType,
        PlaySource playPrompt,
        bool interruptCallMediaOperation,
        RecognizeOptions recognizeOptions,
        string operationContext,
        string operationCallbackUri);

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RecognizeInputType
    {
        [EnumMember(Value = "dtmf")]
        Dtmf,
        [EnumMember(Value = "speech")]
        Speech,
        [EnumMember(Value = "speechOrDtmf")]
        SpeechOrDtmf,
        [EnumMember(Value = "choices")]
        Choices,
    }

    public record RecognizeOptions(
        CommunicationIdentifier targetParticipant,
        bool interruptPrompt,
        int initialSilenceTimeoutInSeconds,
        string speechLanguage,
        string speechRecognitionModelEndpointId,
        DtmfOptions dtmfOptions,
        List<Choice> choices,
        SpeechOptions speechOptions);

    public record DtmfOptions(
        int interToneTimeoutInSeconds,
        int maxTonesToCollect,
        List<Tone> stopTones);

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Tone
    {
        [EnumMember(Value = "zero")]
        Zero,
        [EnumMember(Value = "one")]
        One,
        [EnumMember(Value = "two")]
        Two,
        [EnumMember(Value = "three")]
        Three,
        [EnumMember(Value = "four")]
        Four,
        [EnumMember(Value = "five")]
        Five,
        [EnumMember(Value = "six")]
        Six,
        [EnumMember(Value = "seven")]
        Seven,
        [EnumMember(Value = "eight")]
        Eight,
        [EnumMember(Value = "nine")]
        Nine,
        [EnumMember(Value = "a")]
        A,
        [EnumMember(Value = "b")]
        B,
        [EnumMember(Value = "c")]
        C,
        [EnumMember(Value = "d")]
        D,
        [EnumMember(Value = "pound")]
        Pound,
        [EnumMember(Value = "asterisk")]
        Asterisk
    }

    public record Choice(
        string label,
        List<string> phrases,
        Tone tone);

    public record SpeechOptions(
        int endSilenceTimeoutInMs);

}
