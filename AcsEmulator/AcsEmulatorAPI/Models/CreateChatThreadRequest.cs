#nullable disable

namespace AcsEmulatorAPI.Models
{
	public class CreateChatThreadRequest
	{
		public string Topic { get; set; }

		public List<ChatParticipant> Participants { get; set; }
	}
}
