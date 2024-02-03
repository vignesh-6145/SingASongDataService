using SingASongDataService.Models;

namespace SingASongDataService.Data.Artists
{
    public interface IArtistRepository
    {
        public Artist GetArtist(int ArtistID);
        public IEnumerable<Artist> GetArtists();
        public IEnumerable<Artist> GetTrackArtists(int TrackID);
    }
}
