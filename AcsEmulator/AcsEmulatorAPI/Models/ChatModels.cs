namespace AcsEmulatorAPI.Models
{
	public record CommunicationIdentifier(string RawId);

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
}