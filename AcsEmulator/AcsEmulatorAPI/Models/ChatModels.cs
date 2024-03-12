using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AcsEmulatorAPI.Models
{
	public class CommunicationIdentifier
	{
		public CommunicationIdentifier(string rawId) => RawId = rawId;

		public string RawId { get; set; }

		// todo: support multiple identifier types
		public CommunicationUser CommunicationUser => new(RawId);
	}

	public record CommunicationUser(string Id);

	public record ChatParticipant(
		CommunicationIdentifier CommunicationIdentifier,
		string? DisplayName,
		DateTimeOffset? ShareHistoryTime);

	public record CreateChatThreadRequest(string Topic, List<ChatParticipant>? Participants);

	public record AddChatParticipantsRequest(List<ChatParticipant> Participants);

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ChatMessageType
	{
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "html")]
        Html,
        [EnumMember(Value = "topicUpdated")]
        TopicUpdated,
        [EnumMember(Value = "participantAdded")]
        ParticipantAdded,
        [EnumMember(Value = "participantRemoved")]
        ParticipantRemoved
    }

	public record SendChatMessageRequest(
		string Content,
		string? SenderDisplayName,
		ChatMessageType? Type);

	public record TypingRequest(string? SenderDisplayName);

	// Response of /chat/threads POST
	public record ChatThreadCreation(ChatThreadCreationInfo ChatThread);
	public record ChatThreadCreationInfo(
		string Id,
		string Topic,
		DateTimeOffset? CreatedOn,
		CommunicationIdentifier? CreatedByCommunicationIdentifier);

	// Response of /chat/threads GET
	public record ChatThreadInfo(List<ChatThreadCreationInfo> Value);

	// Response of /chat/threads/{chatThreadId}/participants GET
	public record ChatParticipantsInfo(List<ChatParticipant> Value);
}