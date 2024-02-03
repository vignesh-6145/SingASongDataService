using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SingASongDataService.Models
{
    [Keyless]
    public class TrackGenres
    {
        [Required]
        public int TrackID { get; set; }
        public Track Track { get; set; }
        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
