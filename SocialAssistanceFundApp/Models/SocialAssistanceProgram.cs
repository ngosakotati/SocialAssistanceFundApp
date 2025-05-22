using System.ComponentModel.DataAnnotations;

namespace SocialAssistanceFundApp.Models
{
    public class SocialAssistanceProgram
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
