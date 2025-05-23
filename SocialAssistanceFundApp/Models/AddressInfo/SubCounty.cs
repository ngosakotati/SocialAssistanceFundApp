using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAssistanceFundApp.Models.AddressInfo
{
    public class SubCounty : GenericAddress
    {
        [Key]
        public int Id { get; set; }

        public int CountyId { get; set; }

        // Navigation properties

        [ForeignKey("CountyId")]
        public virtual County County { get; set; }

        public virtual List<Location>? Locations { get; set; } = [];
    }
}
