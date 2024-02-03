using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingASongDataService.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;


        public string PurchaseType { get; set; } = null!;
        public PaymentStatus PurchaseStatus { get; set; }
        public int CartID { get; set; }
        public Cart Cart { get; set; } = null!;
        List<DisountsInfo> Discounts { get; set; } = null!;

    }
}
