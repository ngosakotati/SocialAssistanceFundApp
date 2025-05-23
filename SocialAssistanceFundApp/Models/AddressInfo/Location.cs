using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAssistanceFundApp.Models.AddressInfo
{
    public class Location : GenericAddress
    {
        [Key]
        public int Id { get; set; }

        public int SubCountyId { get; set; }

        // Navigation properties

        [ForeignKey("SubCountyId")]
        public virtual SubCounty SubCounty { get; set; }

        public virtual List<SubLocation>? SubLocations { get; set; } = [];
    }
}
