using SingASongDataService.Models.ViewModels;

namespace SingASongDataService.Data
{
    public interface ITrackRepository
    {
        ViewTrack GetTrack(int _);
        IEnumerable<ViewTrack> GetTracks();
        ViewTrack AddTrack(ViewTrack Track);

        ViewTrack UpdateTrack(ViewTrack _);
        ViewTrack DeleteTrack(int _);
    }
}
