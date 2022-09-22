namespace AcsEmulatorAPI.Models
{
	public class UserChatThread
	{
		public string? DisplayName { get; set; }

		public DateTimeOffset? ShareHistoryTime { get; set; }

		public string UserId { get; set; }
		public virtual User User { get; set; }

		public string ChatThreadId { get; set; }
		public virtual ChatThread ChatThread { get; set; }
	}
}
