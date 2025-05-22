using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAssistanceFundApp.Models.AddressInfo
{
    public class SubCountry : GenericAddress
    {
        [Key]
        public int Id { get; set; }

        public int CountryId { get; set; }

        // Navigation properties

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public virtual List<Location>? Locations { get; set; } = [];
    }
}
