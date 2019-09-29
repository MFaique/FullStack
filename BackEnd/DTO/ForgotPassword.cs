using System.ComponentModel.DataAnnotations;

namespace BackEnd.DTO
{
    public class ForgotPassword
    {
        [EmailAddress]
        public string email { get; set; }
    }
}