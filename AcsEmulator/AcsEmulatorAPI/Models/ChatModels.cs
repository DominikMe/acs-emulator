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

	public enum ChatMessageType
	{
		Text,
		Html,
		TopicUpdated,
		ParticipantAdded,
		ParticipantRemoved
	}

	public record SendChatMessageRequest(
		string Content,
		string? SenderDisplayName,
		ChatMessageType? Type);

	public record TypingRequest(string? SenderDisplayName);
}