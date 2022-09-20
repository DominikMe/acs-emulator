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
    }
}
