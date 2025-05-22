using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAssistanceFundApp.Models.AddressInfo
{
    public class Location : GenericAddress
    {
        [Key]
        public int Id { get; set; }

        public int SubCountryId { get; set; }

        // Navigation properties

        [ForeignKey("SubCountryId")]
        public virtual SubCountry SubCountry { get; set; }

        public virtual List<SubLocation>? SubLocations { get; set; } = [];
    }
}
