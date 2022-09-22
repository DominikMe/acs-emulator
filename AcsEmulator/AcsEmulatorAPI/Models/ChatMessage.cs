namespace AcsEmulatorAPI.Models
{
	public class ChatMessage
	{
		public Guid Id { get; set; }

		public string Content { get; set; }

		public ChatMessageType Type { get; set; }

		public string? SenderDisplayName { get; set; }
	}
}
