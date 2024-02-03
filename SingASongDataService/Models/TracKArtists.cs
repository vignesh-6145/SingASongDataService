using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SingASongDataService.Models
{
    [Keyless]
    public class TracKArtists
    {
        [Required]
        public int TrackID { get; set; }

        public Track Track { get; set; }
        [Required]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
