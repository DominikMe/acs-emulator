using System.ComponentModel.DataAnnotations.Schema;

namespace AcsEmulatorAPI.Models
{
	//[Table("ChatMessages")]
	public class ChatMessage
	{
		public Guid Id { get; set; }

		public string Content { get; set; }

		public ChatMessageType Type { get; set; }

		public virtual User Sender { get; set; }

		public string? SenderDisplayName { get; set; }

		public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

		public int SequenceId { get; set; }
	}

	//[Table("AddParticipantsChatMessages")]
	public class AddParticipantsChatMessage: ChatMessage
	{
		public virtual ICollection<AddedParticipant> AddedParticipants { get; set; }
	}

	public class AddedParticipant
	{
		public Guid Id { get; set; }

		public virtual User Participant { get; set; }

		public string? DisplayName { get; set; }

		public DateTimeOffset? ShareHistoryTime { get; set; }
	}
}
