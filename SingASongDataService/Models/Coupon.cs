using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingASongDataService.Models
{
    public class Coupon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CouponId { get; set; }
        
        public string CouponName { get; set; } = null!;
        public CouponType CouponType { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal Quantity { get; set; }
        public CouponStatus Status { get; set;  }
    }
}
