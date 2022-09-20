#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcsEmulatorAPI.Models
{
    public class User
    {
        private const string ResourceId = "d9b2f18a-2c34-415e-889d-c210cb738186";

        [Column("Id")]
        [Key]
        public string RawId { get; set; }

        public static User CreateNew()
        {
            string userId = Guid.NewGuid().ToString();
            string rawId = $"8:acs:{ResourceId}_{userId}";

            return new User()
            {
                RawId = rawId
            };
        }
    }
}
