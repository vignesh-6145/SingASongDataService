using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.PortableExecutable;

namespace SingASongDataService.Models.ViewModels
{
    public class MockTrackRepository : ITrackRepository
    {
        private List<Track> Tracks;

        public MockTrackRepository()
        {
            var serializer = new JsonSerializer();
            this.Tracks = new List<Track>();
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
        private Track ConvertToTrack(JObject obj)
        {
            Track track = new Track();
            track.Name = (string)obj["Name"];
            track.TrackId = int.Parse((string)obj["TrackID"]);
            track.Album = (string)obj["Album"];
            track.Artists = new List<string>();
            track.Artists.Add((string)obj["Artist"][0]);

            track.Genres = new List<string>();
            track.Genres.Add((string)obj["Genre"][0]);
            return track;

        }

        public Track GetTrack(int Id)
        {
            return Tracks.Where(trck => trck.TrackId == Id).First();
        }

        public IEnumerable<Track> GetTracks()
        {
            return Tracks;
        }

        public Track DeleteTrack(int id)
        {
            var track = Tracks.Where(t => t.TrackId == id).FirstOrDefault();
            if (track == null)
                return null;
            Tracks.Remove(track);
            return track;
        }
        public Track UpdateTrack(Track Track)
        {
            var track = Tracks.Where(t => t.TrackId == Track.TrackId).FirstOrDefault();
            if (track == null)
                return null;
            Tracks.Remove(track);
            Tracks.Add(Track);
            return Track;
        }
        public Track AddTrack(Track Track)
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
