using System.ComponentModel.DataAnnotations;

namespace FullStack.Models
{
    public class UserAddress
    {
        [Key]
        public int id { get; set; }
        public string address { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
    }
}