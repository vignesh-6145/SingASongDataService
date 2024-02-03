using SingASongDataService.Models;

namespace SingASongDataService.Data.Albums
{
    public interface IAlbumRepository
    {
        public Album GetAlbum(int AlbumID);
        public IEnumerable<Album> GetAlbums();
    }
}
