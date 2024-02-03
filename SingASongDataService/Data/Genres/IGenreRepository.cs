using SingASongDataService.Models;
namespace SingASongDataService.Data.Genres
{
    public interface IGenreRepository
    {
        public Genre GetGenre(int GenreID);
        public IEnumerable<Genre> GetGenres();
        public IEnumerable<Genre> GetTrackGenres(int TrackID);

    }
}
