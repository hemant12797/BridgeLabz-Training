using System;

namespace FitTrack
{
    public class UserProfile
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; } // in kg
        public double Height { get; set; } // in cm

        public UserProfile(string name, int age, double weight, double height)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
        }

        public void DisplayProfile()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Weight: {Weight}kg, Height: {Height}cm");
        }
    }
}
