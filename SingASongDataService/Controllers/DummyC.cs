using Microsoft.AspNetCore.Mvc;
using SingASongDataService.Models;
using SingASongDataService.Models.ViewModels;

namespace SingASongDataService.Controllers
{
   //sd/de
    public class DummyC : Controller
    {
        //Dummy Data to Test API's
        IEnumerable<ViewTrack> tracks;
        MockTrackRepository trackRepository;
        
        public DummyC()
        {
            trackRepository = new MockTrackRepository();

        }
        /* Read Operations */
        //// GetASong
        //[HttpGet]
        //[Route("Data/Tracks/{TrackID}")]
        public ViewTrack GetTrack(int TrackID)
        {
            ViewTrack trck = trackRepository.GetTrack(TrackID);
            return trck;
        }
        //GetSongs

        //[HttpGet]
        //[Route("Data/Tracks/GetAllTracks")]
        //public IEnumerable<ViewTrack> GetAllTracks()
        //{
        //    return trackRepository.GetTracks();
        //}

        /*  Write Operations  */
        //Add A Song
        //[HttpPost]
        //[Route("Data/AddTrack")]
        //public ViewTrack AddTrack([FromBody] ViewTrack track)
        //{
        //    return trackRepository.AddTrack(track);
            
        //}
        //Update A Song
        [HttpPut]
        [Route("Data/UpdateTrack")]
        public ViewTrack UpdateTrack([FromBody] ViewTrack track)
        {
            return trackRepository.UpdateTrack(track); 
        }

        //Delete A Song
        [HttpDelete]
        [Route("Data/Tracks/{TrackID}")]
        public ViewTrack DeleteTrack(int TrackID)
        {
            return trackRepository.DeleteTrack(TrackID);
        }


    }
}
