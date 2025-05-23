using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAssistanceFundApp.Models.ApplicantInfo
{
    public class TelephoneContact
    {
        [Key]
        public int Id { get; set; }

        public int ApplicantId { get; set; }

        public string TelephoneNo { get; set; }

        // Navigation properties

        [ForeignKey("ApplicantId")]
        public Applicant Applicant { get; set; }
    }
}
