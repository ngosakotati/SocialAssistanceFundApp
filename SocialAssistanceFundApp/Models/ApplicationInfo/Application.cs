using SocialAssistanceFundApp.Models.ApplicantInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAssistanceFundApp.Models.ApplicationInfo
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        public int ApplicantId { get; set; }

        public int SocialAssistanceProgramId { get; set; }

        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; } = false;

        // Navigation properties

        [ForeignKey("ApplicantId")]
        public virtual Applicant Applicant { get; set; }

        [ForeignKey("SocialAssistanceProgramId")]
        public SocialAssistanceProgram SocialAssistanceProgram { get; set; }
    }
}
