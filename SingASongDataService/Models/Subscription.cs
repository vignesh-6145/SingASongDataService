using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingASongDataService.Models
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionID { get; set; }
        public string Name { get; set; } = null!;
        public int Duration { get; set; } //in months
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
