#nullable disable

namespace AcsEmulatorAPI.Models
{
	public class ChatThreadProperties
	{
		public string Id { get; set; }

		public string Topic { get; set; }

		public DateTimeOffset CreatedOn { get; set; }

		public CommunicationIdentifier CreatedByCommunicationIdentifier { get; set; }
	}
}
