﻿#nullable disable

namespace AcsEmulatorAPI.Models
{
	public class ChatThread
	{
		public string Id { get; set; }

		public string Topic { get; set; }

		public DateTimeOffset CreatedOn { get; set; }

		public User CreatedBy { get; set; }

		public virtual ICollection<User> Participants { get; set; }
		public virtual List<UserChatThread> UserChatThreads { get; set; }

		public static ChatThread CreateNew(string topic, User createdBy)
		{
			return new ChatThread
			{ 
				Id = $"19:{Guid.NewGuid()}",
				Topic = topic,
				CreatedOn = DateTimeOffset.Now,
				CreatedBy = createdBy
			};
		}
	}
}
