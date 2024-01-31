namespace SingASongDataService.Models.ViewModels
{
    public interface ITrackRepository
    {
        Track GetTrack(int _);
        IEnumerable<Track> GetTracks();
        Track AddTrack(Track Track);

        Track UpdateTrack(Track _);
        Track DeleteTrack(int _);
    }
}
