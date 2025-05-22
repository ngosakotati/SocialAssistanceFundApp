using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAssistanceFundApp.Models
{
    public class Approval
    {
        [Key]
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public string ApproverId { get; set; }

        // Navigation properties

        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }

        [ForeignKey("ApproverId")]
        public virtual Approver Approver { get; set; }
    }
}
