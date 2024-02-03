using SingASongDataService.Models;

namespace SingASongDataService.Data.Artists
{
    public class ArtistRepository : IArtistRepository
    {
        SingASongContext _context;

        public ArtistRepository()
        {
            _context = new SingASongContext();
        }

        public ArtistRepository(SingASongContext context)
        {
            _context = context;
        }
        public Artist GetArtist(int ArtistID)
        {
            try
            {
                return _context.Artists.First(artst => artst.ArtistId == ArtistID);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"No Such Artist with ID : {ArtistID}");
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public IEnumerable<Artist> GetArtists()
        {
            return _context.Artists;
        }
        public IEnumerable<Artist> GetTrackArtists(int TrackID)
        {
            try
            {
                var artisIDS = _context.TracKArtists.Where(trck => trck.TrackID == TrackID).Select(record => record.ArtistId);
                var artists = _context.Artists.Join(
                    artisIDS,
                    artistID => artistID.ArtistId,
                    artist => artist,
                    (artist,artisIDS) => new Artist(){ ArtistName =  artist.ArtistName }
                    );
                foreach(Artist artist in artists)
                {
                    Console.WriteLine(artist);
                }
                return artists;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Track has not artist information");
                Console.WriteLine(ex.Message);  
            }
            return null;
            
            
        }
    }
}
