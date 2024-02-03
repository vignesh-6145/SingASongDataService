using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SingASongDataService.Models
{
    [Keyless]
    public class DisountsInfo
    {
        [Required]
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
        [Required]
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }
    }
}
