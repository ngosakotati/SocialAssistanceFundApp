using System.ComponentModel.DataAnnotations;

namespace SocialAssistanceFundApp.Models.AddressInfo
{
    public class County : GenericAddress
    {
        [Key]
        public int Id { get; set; }

        // Navigation properties
        public virtual List<SubCounty>? SubCounties { get; set; } = [];
    }
}
