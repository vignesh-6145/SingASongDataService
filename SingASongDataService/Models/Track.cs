using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingASongDataService.Models
{
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        
        public int AlbumID { get; set; }
        [Column(TypeName = "decimal(6,2)")]

        public decimal Price { get; set; }
    }
}
