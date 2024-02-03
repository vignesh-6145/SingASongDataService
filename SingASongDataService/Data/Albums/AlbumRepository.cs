using SingASongDataService.Models;

namespace SingASongDataService.Data.Albums
{
    public class AlbumRepository : IAlbumRepository
    {
        SingASongContext _context;
        public AlbumRepository() {
            _context = new SingASongContext();
        }

        public Album GetAlbum(int AlbumID) {
            try
            {
                return _context.Albums.First(albm => albm.AlbumID == AlbumID);
            }catch (Exception ex)
            {
                Console.WriteLine($"No such Album with ID {AlbumID}");
                Console.WriteLine(ex.Message); 
            }
            return null;
        }
        public IEnumerable<Album> GetAlbums()
        {
            return _context.Albums;
        }
        
    }
}
