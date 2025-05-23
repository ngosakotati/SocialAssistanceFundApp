using System.ComponentModel.DataAnnotations;

namespace SocialAssistanceFundApp.Models.ViewModels
{
    public class CreateApplicationViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; }
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string IdNumber { get; set; }

        [Required]
        public int CountyId { get; set; }

        [Required]
        public int SubCountyId { get; set; }

        public string PostalAddress { get; set; }
        public string PhysicalAddress { get; set; }

        [Required]
        public List<string>? TelephoneContacts { get; set; } = [];

        [Required]
        public int SocialAssistanceProgramId { get; set; }

        public string? OtherProgramDescription { get; set; }

        [Required]
        public bool DeclarationAccepted { get; set; } = false;

        [Required]
        public int SexId { get; set; }

        [Required]
        public int MaritalStatusId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public int SubLocationId { get; set; }
        [Required]
        public int VillageId { get; set; }

    }
}
