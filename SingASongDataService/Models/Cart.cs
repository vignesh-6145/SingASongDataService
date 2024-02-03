using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingASongDataService.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        [Required]
        public int Status { get; set; }

        //public ICollection<CartTrack> Tracks { get; set; } = null!;
    }
}
