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
        // [Required, EmailAddress]
        [EmailAddress]
        public string email { get; set; }

        [DisplayName("Password")]
        // [Required, MinLength(6), MaxLength(32)]
        public string password { get; set; }

        [DisplayName("National Identity")]
        // [Required, MaxLength(32)]
        [MaxLength(32)]
        public string nationalId { get; set; }

        [DisplayName("Roll Number")]
        [MaxLength(10)]
        public string rollNo { get; set; }

        [DisplayName("Enrolment Number")]
        [MaxLength(20)]
        public string enrolNo { get; set; }

        [DisplayName("Batch")]
        // [Required]
        public int? batchId { get; set; }

        [DisplayName("Discipline")]
        // [Required]
        public int? disciplineId { get; set; }

        [DisplayName("Profile Image Link")]
        public string imageUrl { get; set; }

        [DisplayName("City")]
        public int? cityId { get; set; }

        [DisplayName("Country")]
        public int? countryId { get; set; }

        [DisplayName("Phone Number")]
        public string phoneNumber { get; set; }

    }
}