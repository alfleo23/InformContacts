using System.ComponentModel.DataAnnotations;

namespace InformContacts.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? Company { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
