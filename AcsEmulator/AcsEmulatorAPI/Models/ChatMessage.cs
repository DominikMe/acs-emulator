using System.ComponentModel.DataAnnotations.Schema;

namespace AcsEmulatorAPI.Models
{
	[Table("ChatMessages")]
	public class ChatMessage
	{
		public Guid Id { get; set; }

		public string Content { get; set; }

		public ChatMessageType Type { get; set; }

		public User Sender { get; set; }

		public string? SenderDisplayName { get; set; }

		public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

		public int SequenceId { get; set; }
	}
}
