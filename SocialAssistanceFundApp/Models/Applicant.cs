using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAssistanceFundApp.Models
{
    public class Applicant
    {
        [Key] 
        public int Id { get; set; }

        public int SexId { get; set; }

        public int MaritalStatusId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "ID Number cannot be longer than 20 characters")]
        public string IdNumber { get; set; }

        [Required]
        public string PostalAddress { get; set; }

        [Required]
        public string PhysicalAddress { get; set; }

        public string? SignatureUrl { get; set; }

        // Navigation properties

        [ForeignKey("SexId")]
        public virtual Sex Sex { get; set; }

        [ForeignKey("MaritalStatusId")]
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual List<TelephoneContact>? TelephoneContacts { get; set; } = [];
    }
}
