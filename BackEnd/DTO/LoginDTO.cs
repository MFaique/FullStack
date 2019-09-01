using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO
{
    public class LoginDTO
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}