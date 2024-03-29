﻿namespace SingASongDataService.Models.ViewModels
{
    public interface ITrackRepositoryDummy
    {
        ViewTrack GetTrack(int _);
        IEnumerable<ViewTrack> GetTracks();
        ViewTrack AddTrack(ViewTrack Track);

        ViewTrack UpdateTrack(ViewTrack _);
        ViewTrack DeleteTrack(int _);
    }
}
