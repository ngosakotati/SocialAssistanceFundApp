using System.ComponentModel.DataAnnotations;

namespace SocialAssistanceFundApp.Models.ViewModels
{
    public class ApplicationViewModel
    {
        public int Id { get; set; }
        public string? SocialAssistanceProgram { get; set; }

        public DateTime? ApplicationDate { get; set; } 

        public ApplicantViewModel? Applicant { get; set; }
    }
}
