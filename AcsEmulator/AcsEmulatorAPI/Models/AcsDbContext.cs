#nullable disable

using Microsoft.EntityFrameworkCore;

namespace AcsEmulatorAPI.Models
{
    public class AcsDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public AcsDbContext(DbContextOptions<AcsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
