#nullable disable

using Microsoft.EntityFrameworkCore;

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
				CreatedBy = createdBy,

				Participants = new List<User>(),
				UserChatThreads = new List<UserChatThread>()
			};
		}

		// TODO: maybe shouldn't pass db context
		public async Task AddParticipants(AcsDbContext db, IEnumerable<ChatParticipant> participants)
		{
			foreach (var requestParticipant in participants)
			{
				// TODO: Not efficient to look up in a loop
				var participantToAdd = await db.Users
					.Include(u => u.Threads)
					.Include(u => u.UserChatThreads)
					.FirstOrDefaultAsync(u => u.RawId == requestParticipant.CommunicationIdentifier.RawId);

				if (participantToAdd == null)
				{
					// TODO: add to "invalidParticipants"
					continue;
				}

				var uct = new UserChatThread
				{
					User = participantToAdd,
					ChatThread = this,

					ShareHistoryTime = requestParticipant.ShareHistoryTime,
					DisplayName = requestParticipant.DisplayName
				};

				Participants.Add(participantToAdd);
				UserChatThreads.Add(uct);

				participantToAdd.Threads.Add(this);
				participantToAdd.UserChatThreads.Add(uct);
			}
		}
	}
}
