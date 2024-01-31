using Microsoft.AspNetCore.Mvc;
using SingASongDataService.Models;
using SingASongDataService.Models.ViewModels;

namespace SingASongDataService.Controllers
{
   //sd/de
    public class SingASongDataController : Controller
    {
        //Dummy Data to Test API's
        IEnumerable<ShoppingItemViewModel> tracks;
        MockTrackRepository trackRepository;
        
        public SingASongDataController()
        {
            trackRepository = new MockTrackRepository();

        }
        /* Read Operations */
        // GetASong
        [HttpGet]
        [Route("Data/Tracks/{TrackID}")]
        public Track GetTrack(int TrackID)
        {
            return trackRepository.GetTrack(TrackID);
        }
        //GetSongs

        [HttpGet]
        [Route("Data/Tracks/GetAllTracks")]
        public IEnumerable<Track> GetAllTracks()
        {
            return trackRepository.GetTracks();
        }

        /*  Write Operations  */
        //Add A Song
        [HttpPost]
        [Route("Data/Tracks")]
        public Track AddTrack([FromBody]Track track)
        {
            return trackRepository.AddTrack(track);
            
        }
        //Update A Song
        [HttpPut]
        [Route("Data/Tracks")]
        public Track UpdateTrack([FromBody]Track track)
        {
            return trackRepository.UpdateTrack(track); 
        }

        //Delete A Song
        [HttpDelete]
        [Route("Data/Tracks/{TrackID}")]
        public Track DeleteTrack(int TrackID)
        {
            return trackRepository.DeleteTrack(TrackID);
        }
    }
}
