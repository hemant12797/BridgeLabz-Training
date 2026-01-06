namespace RideHailingApplication
{
    public interface IGPS
    {
        string GetCurrentLocation();
        void UpdateLocation(string location);
    }
}
