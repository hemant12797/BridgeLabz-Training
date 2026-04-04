using System;

namespace TrafficManager
{
    public class Vehicle
    {
        public string LicensePlate { get; set; }
        public Vehicle Next { get; set; }

        public Vehicle(string licensePlate)
        {
            LicensePlate = licensePlate;
            Next = null;
        }
    }
}
