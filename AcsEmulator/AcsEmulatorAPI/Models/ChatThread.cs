#nullable disable

namespace AcsEmulatorAPI.Models
{
	public class ChatThread
	{
		public string Id { get; set; }

		public string Topic { get; set; }

		public DateTimeOffset CreatedOn { get; set; }

		public static ChatThread CreateNew(string topic)
		{
			return new ChatThread
			{ 
				Id = $"19:{Guid.NewGuid()}",
				Topic = topic,
				CreatedOn = DateTimeOffset.Now
			};
		}
	}
}
