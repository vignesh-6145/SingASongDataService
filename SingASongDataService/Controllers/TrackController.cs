using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SingASongDataService.Data;
using SingASongDataService.Data.Albums;
using SingASongDataService.Data.Artists;
using SingASongDataService.Data.Genres;
using SingASongDataService.Models;
using SingASongDataService.Models.ViewModels;
using System.Net;

namespace SingASongDataService.Controllers
{
    public class TrackController : Controller
    {
        TrackRepository trackRepository;
        AlbumRepository albumRepository;
        ArtistRepository artistRepository;
        GenreRepository genreRepository;

        public TrackController()
        {
            this.trackRepository = new TrackRepository();
            this.albumRepository = new AlbumRepository();
            this.artistRepository = new ArtistRepository();
            this.genreRepository = new GenreRepository();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Data/Tracks/{TrackID}")]
        public IActionResult GetTrack(int TrackID)
        { 
            Track trck = trackRepository.GetTrack(TrackID);
            if(trck == null)
            {
                return NotFound();
                
            }
            return Ok(trck);
        }

        [HttpGet]
        [Route("Data/Tracks/GetAllTracks")]
        public IActionResult GetAllTracks()
        {
            return Ok(trackRepository.GetTracks());
        }

        [HttpGet]
        [Route("Data/Albums/{AlbumID}")]
        public IActionResult GetAlbum(int AlbumID)
        {
            Album album = albumRepository.GetAlbum(AlbumID);
            if(album != null)
            {
                return Ok(album);
            }
            return NotFound("No Record Found");
        }

        [HttpGet]
        [Route("Data/Albums")]
        public IActionResult GetAlbums()
        {
            return Ok(albumRepository.GetAlbums());
        }

        [HttpGet]
        [Route("Data/Artists")]
        public IActionResult GetArtists() {
            return Ok(artistRepository.GetArtists());
        }

        [HttpGet]
        [Route("Data/Artists/{ArtistID}")]
        public IActionResult GetTracks(int ArtistID)
        {
            Artist artist = artistRepository.GetArtist(ArtistID);
            if(artist != null) {
                return Ok(artist);
            }
            return NotFound($"No Artist with ID : {ArtistID}");

        }
        [HttpGet]
        [Route("Data/Tracks/{TrackID}/Artists")]
        public IActionResult TrackArtists(int TrackID)
        {
            return Ok(artistRepository.GetTrackArtists(TrackID));
        }

        [HttpGet]
        [Route("Data/Genres")]
        public IActionResult GetGenres()
        {
            return Ok(genreRepository.GetGenres());
        }
        [HttpGet]
        [Route("Data/Tracks/{TrackID}/Genres")]
        public IActionResult TrackGenres(int TrackID)
        {
            return Ok(genreRepository.GetTrackGenres(TrackID));
        }
        [HttpGet]
        [Route("Data/Genres/{GenreID}")]
        public IActionResult GetGenre(int GenreID)
        {
            var genre = genreRepository.GetGenre(GenreID);
            if(genre != null)
            {
                return Ok(genre);
            }
            return NotFound($"No Genre with ID {GenreID}");
        }
    }
}
