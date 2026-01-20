namespace ParcelTracker
{
    internal interface ITracker
    {
        void AddParcel();
        void UpdateStage();
        void TrackParcel();
        void TrackAll();
    }
}