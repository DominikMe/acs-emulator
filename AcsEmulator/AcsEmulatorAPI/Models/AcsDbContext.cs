#nullable disable

using Microsoft.EntityFrameworkCore;

namespace AcsEmulatorAPI.Models
{
    public class AcsDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<ChatThread> ChatThreads { get; set; }

        public DbSet<SmsMessage> SmsMessages { get; set; }

		public DbSet<EmailMessageInternal> EmailMessages { get; set; }

        public DbSet<CallConnection> CallConnections { get; set; }

        public AcsDbContext(DbContextOptions<AcsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChatMessage>().ToTable("ChatMessages");
			builder.Entity<AddParticipantsChatMessage>().ToTable("AddParticipantsChatMessages");
            builder.Entity<CallConnectionTarget>().ToTable("CallConnectionTargets");

			builder.Entity<ChatThread>()
                .HasOne(t => t.CreatedBy)
                .WithMany();

            builder.Entity<User>()
                .HasMany(u => u.Threads)
                .WithMany(t => t.Participants)
                .UsingEntity<UserChatThread>(
                    j => j
                        .HasOne(uct => uct.ChatThread)
                        .WithMany(t => t.UserChatThreads)
                        .HasForeignKey(uct => uct.ChatThreadId),
                    j => j
                        .HasOne(uct => uct.User)
                        .WithMany(u => u.UserChatThreads)
                        .HasForeignKey(uct => uct.UserId),
                    j =>
                    {
                        j.HasKey(uct => new { uct.UserId, uct.ChatThreadId });
                    });

            builder.Entity<CallConnection>()
                .Property(u => u.CallConnectionState)
                .HasConversion<string>();
        }
    }
}
