#nullable disable

namespace AcsEmulatorAPI.Models
{
	public class ChatParticipant
	{
		public CommunicationIdentifier CommunicationIdentifier { get; set; }

		public string DisplayName { get; set; }

		public DateTimeOffset ShareHistoryTime { get; set; }
	}
}
