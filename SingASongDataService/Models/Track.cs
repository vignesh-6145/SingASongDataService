namespace SingASongDataService.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public List<string> Artists { get; set; }
        public List<string> Genres { get; set; }
        public string Album { get; set; }
    }
}
