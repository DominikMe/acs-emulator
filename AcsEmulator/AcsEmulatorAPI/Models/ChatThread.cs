#nullable disable

using Microsoft.EntityFrameworkCore;

namespace AcsEmulatorAPI.Models
{
	public class ChatThread
	{
		public string Id { get; set; }

		public string Topic { get; set; }

		public DateTimeOffset CreatedOn { get; set; }

		public virtual User CreatedBy { get; set; }

		public virtual ICollection<User> Participants { get; set; }
		public virtual List<UserChatThread> UserChatThreads { get; set; }

		public virtual ICollection<ChatMessage> Messages { get; set; }

		public static ChatThread CreateNew(string topic, User createdBy)
		{
			return new ChatThread
			{ 
				Id = $"19:{Guid.NewGuid()}",
				Topic = topic,
				CreatedOn = DateTimeOffset.UtcNow,
				CreatedBy = createdBy,
				Participants = new List<User>(),
				UserChatThreads = new List<UserChatThread>(),
				Messages = new List<ChatMessage>()
			};
		}

		// TODO: maybe shouldn't pass db context
		public async Task AddParticipants(AcsDbContext db, User initiator, IEnumerable<ChatParticipant> participants)
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

				// Send a "participant added" message to the thread
				int nextSequenceId = Messages.Count + 1;
				var apm = new AddParticipantsChatMessage
				{
					// TODO: where is this Content used?
					Content = $"Participant {requestParticipant.DisplayName ?? "Unknown"} added",

					Sender = initiator,
					Type = ChatMessageType.ParticipantAdded,
					SequenceId = nextSequenceId,

					AddedParticipants = new List<AddedParticipant>
					{
						// TODO: duplicating "UserChatThread" - ok or not?
						new AddedParticipant
						{
							Participant = participantToAdd,

							ShareHistoryTime = requestParticipant.ShareHistoryTime,
							DisplayName = requestParticipant.DisplayName
						}
					}
				};
				Messages.Add(apm);

				Participants.Add(participantToAdd);
				UserChatThreads.Add(uct);

				participantToAdd.Threads.Add(this);
				participantToAdd.UserChatThreads.Add(uct);
			}
		}
	}
}
