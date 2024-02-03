using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SingASongDataService.Models
{
    [Keyless]
    public class CartTrack
    {
        
        [Required]
        public int CartId { get; set; } 
        public Cart Cart { get; set; } = null!;
        [Required]
        public int TrackId { get; set; }
        public Track Track { get; set; } = null!;
    }
}
