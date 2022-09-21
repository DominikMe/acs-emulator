#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcsEmulatorAPI.Models
{
    public class User
    {
        [Column("Id")]
        [Key]
        public string RawId { get; set; }

        public ICollection<ChatThread> Threads { get; set; }

        public static User CreateNew(string resourceId)
        {
            string userId = Guid.NewGuid().ToString();
            string rawId = $"8:acs:{resourceId}_{userId}";

            return new User()
            {
                RawId = rawId
            };
        }
    }
}
