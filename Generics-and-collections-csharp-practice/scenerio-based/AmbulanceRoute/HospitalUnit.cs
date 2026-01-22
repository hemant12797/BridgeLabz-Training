using System;

namespace AmbulanceRoute
{
    public class HospitalUnit
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public HospitalUnit Next { get; set; }

        public HospitalUnit(string name)
        {
            Name = name;
            IsAvailable = true; // Assume available by default
            Next = null;
        }
    }
}
