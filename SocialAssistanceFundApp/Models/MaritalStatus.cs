using System.ComponentModel.DataAnnotations;

namespace SocialAssistanceFundApp.Models
{
    public class MaritalStatus
    {
        [Key]
        public int Id { get; set; }

        public string Status { get; set; }
    }
}
