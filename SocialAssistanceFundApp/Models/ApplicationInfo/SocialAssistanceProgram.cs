using System.ComponentModel.DataAnnotations;

namespace SocialAssistanceFundApp.Models.ApplicationInfo
{
    public class SocialAssistanceProgram
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
