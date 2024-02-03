using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SingASongDataService.Models
{
    public class UserTracks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set;}
        public User Users { get; set; } = null!;
        [Required]
        public int TrackID { get; set; }
        public Track Track { get; set; } = null!;
    }
}
