using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AcsEmulatorAPI.Models
{
	[Table("ChatMessages")]
	public class ChatMessage
	{
		public Guid Id { get; set; }

		public string Content { get; set; }

		public ChatMessageType Type { get; set; }

		public virtual User Sender { get; set; }

		public string? SenderDisplayName { get; set; }

		public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

		// SequenceId is sent as String in (/chat/threads/{thread_id}/messages)
        public string SequenceId { get; set; }

		public string? VersionId { get; set; }
	}

	[Table("AddParticipantsChatMessages")]
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


	// ChatMessage in Payload do not match above record ( SequenceId is string, and many other fields are missing)
	// Creating another one, but will need to be merged
    // Response of /chat/threads/{thread_id}/messages GET
	public record ChatMessagesResponse(List<ChatMessage> Value);
}
