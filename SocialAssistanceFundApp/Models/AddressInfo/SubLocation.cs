using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAssistanceFundApp.Models.AddressInfo
{
    public class SubLocation : GenericAddress
    {
        [Key]
        public int Id { get; set; }

        public int LocationId { get; set; }

        // Navigation properties

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public virtual List<Village>? Villages { get; set; } = [];
    }
}
