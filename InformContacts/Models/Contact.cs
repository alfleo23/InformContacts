using System.ComponentModel.DataAnnotations;

namespace InformContacts.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [MaxLength(30)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string? LastName { get; set; }

        [MaxLength(50)]
        public string? Company { get; set; }

        [MaxLength (20)]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string? PhoneNumber { get; set; }

    }
}
