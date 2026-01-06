using System;

namespace RideHailingApplication
{
    public class Car : Vehicle, IGPS
    {
        private string currentLocation;

        public string CurrentLocation
        {
            get { return currentLocation; }
            set { currentLocation = value; }
        }

        public override double CalculateFare(double distance)
        {
            return RatePerKm * distance;
        }

        public string GetCurrentLocation()
        {
            return CurrentLocation;
        }

        public void UpdateLocation(string location)
        {
            CurrentLocation = location;
        }
    }
}
