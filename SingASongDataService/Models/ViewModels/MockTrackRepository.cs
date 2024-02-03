using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.PortableExecutable;

namespace SingASongDataService.Models.ViewModels
{
    public class MockTrackRepository 
    {
        private List<ViewTrack> Tracks;

        public MockTrackRepository()
        {
            var serializer = new JsonSerializer();
            this.Tracks = new List<ViewTrack>();
            using (var streamReader = new StreamReader(@"C:\Users\bandla.vignesh\source\repos\SingASongDataService\SingASongDataService\Data\DummyData.json"))
            using (var textReader = new JsonTextReader(streamReader))
            {
                JArray obj = (JArray)JToken.ReadFrom(textReader);
                foreach (var track in obj)
                {
                    Tracks.Add(ConvertToTrack((JObject)track));
                }
            }
        }
        private ViewTrack ConvertToTrack(JObject obj)
        {
            ViewTrack track = new ViewTrack();
            track.Name = (string)obj["Name"];
            track.TrackId = int.Parse((string)obj["TrackID"]);
            track.Album = (string)obj["Album"];
            track.Artists = new List<string>();
            track.Artists.Add((string)obj["Artist"][0]);

            track.Genres = new List<string>();
            track.Genres.Add((string)obj["Genre"][0]);
            return track;

        }

        public ViewTrack GetTrack(int Id)
        {
            return Tracks.Where(trck => trck.TrackId == Id).First();
        }

        public IEnumerable<ViewTrack> GetTracks()
        {
            return Tracks;
        }

        public ViewTrack DeleteTrack(int id)
        {
            var track = Tracks.Where(t => t.TrackId == id).FirstOrDefault();
            if (track == null)
                return null;
            Tracks.Remove(track);
            return track;
        }
        public ViewTrack UpdateTrack(ViewTrack Track)
        {
            var track = Tracks.Where(t => t.TrackId == Track.TrackId).FirstOrDefault();
            if (track == null)
                return null;
            Tracks.Remove(track);
            Tracks.Add(Track);
            return Track;
        }
        public ViewTrack AddTrack(ViewTrack Track)
        {
            if(Track.TrackId == 0)
            {
                int id = Tracks.Last().TrackId;
                Track.TrackId = id + 1;
            }
            Tracks.Add(Track);
            return Track;
        }
    }
}
