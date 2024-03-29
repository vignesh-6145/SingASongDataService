﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingASongDataService.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumID { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly? RealeasedOn { get; set; }
        public int  ProviderID {get;set;}
        public Provider Provider { get; set; } = null!;
        public ICollection<Track> Tracks { get; set; } = null!;
    }
}
