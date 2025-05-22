using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialAssistanceFundApp.Models.AddressInfo
{
    public class Village
    {
        [Key]
        public int Id { get; set; }

        public int SubLocationId { get; set; }

        // Navigation properties

        [ForeignKey("SubLocationId")]
        public virtual SubLocation SubLocation { get; set; }

    }
}
