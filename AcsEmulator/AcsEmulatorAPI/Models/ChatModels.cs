namespace AcsEmulatorAPI.Models
{
	public record CommunicationIdentifier(string RawId);

	public record ChatParticipant(
		CommunicationIdentifier CommunicationIdentifier,
		string? DisplayName,
		DateTimeOffset? ShareHistoryTime);

	public record CreateChatThreadRequest(string Topic, List<ChatParticipant>? Participants);

	public record AddChatParticipantsRequest(List<ChatParticipant> Participants);
}