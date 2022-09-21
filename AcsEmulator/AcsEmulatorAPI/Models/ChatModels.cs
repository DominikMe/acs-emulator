namespace AcsEmulatorAPI.Models
{
	record CommunicationIdentifier(string RawId);

	record ChatParticipant(
		CommunicationIdentifier CommunicationIdentifier,
		string DisplayName,
		DateTimeOffset ShareHistoryTime);

	record CreateChatThreadRequest(string Topic, List<ChatParticipant> Participants);

	record AddChatParticipantsRequest(List<ChatParticipant> Participants);
}