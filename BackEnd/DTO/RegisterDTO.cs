using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO
{
    public class RegisterDTO
    {
        [DisplayName("Full Name")]
        [Required, MaxLength(32)]
        public string name { get; set; }

        [DisplayName("Email")]
        [Required, EmailAddress]
        public string email { get; set; }

        [DisplayName("Password")]
        [Required, MinLength(6), MaxLength(32)]
        public string password { get; set; }

        [DisplayName("National Identity")]
        public string nationalId { get; set; }
    }
}