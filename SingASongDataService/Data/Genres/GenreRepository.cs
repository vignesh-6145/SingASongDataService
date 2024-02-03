using SingASongDataService.Models;

namespace SingASongDataService.Data.Genres
{
    public class GenreRepository:IGenreRepository
    {
        SingASongContext context;
        public GenreRepository()
        {
            context = new SingASongContext();
        }
        public Genre GetGenre(int GenreID)
        {
            return context.Genres.First(gnr => gnr.Id==GenreID);
        }
        public IEnumerable<Genre> GetGenres()
        {
            return context.Genres;
        }
        public IEnumerable<Genre> GetTrackGenres(int TrackID)
        {
            var genreIDS = context.TrackGenres.Where(record => record.TrackID == TrackID).Select(record => record.GenreId);
            IEnumerable<Genre> genres = context.Genres.Join(
                genreIDS,
                genre => genre.Id,
                genreId => genreId,
                (genre,genreId) => new Genre()
                {
                    Id = genre.Id,
                    Name = genre.Name
                }
                );
            return genres;
        }
    }
}
