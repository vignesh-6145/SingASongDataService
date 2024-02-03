using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SingASongDataService.Models
{
    [Keyless]
    public class Subscriber
    {
        [Required]
        public int SubscriptionID { get; set; }
        public Subscription Subscription { get; set; } = null!;
        [Required]
        public int UserID { get; set; }
        public User User { get; set; } = null!;
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set;}
    }
}
