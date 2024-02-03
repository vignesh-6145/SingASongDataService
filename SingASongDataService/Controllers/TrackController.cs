using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SingASongDataService.Data;
using SingASongDataService.Models;
using SingASongDataService.Models.ViewModels;
using System.Net;

namespace SingASongDataService.Controllers
{
    public class TrackController : Controller
    {
        TrackRepository trackRepository;

        public TrackController()
        {
            this.trackRepository = new TrackRepository();
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

       
    }
}
