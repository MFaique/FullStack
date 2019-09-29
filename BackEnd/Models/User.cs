using System.ComponentModel.DataAnnotations;

namespace FullStack.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public string name { get; set; }
        public string nationalId { get; set; }

        public string email { get; set; }

        public byte[] passwordSalt { get; set; }
        public byte[] passwordHash { get; set; }
    }
}