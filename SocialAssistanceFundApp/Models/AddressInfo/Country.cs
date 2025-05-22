using System.ComponentModel.DataAnnotations;

namespace SocialAssistanceFundApp.Models.AddressInfo
{
    public class Country : GenericAddress
    {
        [Key]
        public int Id { get; set; }

        // Navigation properties
        public virtual List<SubCountry>? SubCountries { get; set; } = [];
    }
}
