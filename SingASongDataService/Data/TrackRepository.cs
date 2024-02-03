using Microsoft.AspNetCore.Mvc;
using SingASongDataService.Models;
using SingASongDataService.Models.ViewModels;

namespace SingASongDataService.Data
{
    public class TrackRepository
    {
        SingASongContext _context;
        public TrackRepository()
        {
            _context = new SingASongContext();
        }

        public Track GetTrack(int TrackId)
        {
            return _context.Tracks.Where(trck => trck.TrackId == TrackId).First();
        }

        public IEnumerable<Track> GetTracks() {
            return _context.Tracks;
        }

        
    }
}
