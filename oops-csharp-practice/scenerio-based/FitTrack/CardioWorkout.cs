using System;

namespace FitTrack
{
    public class CardioWorkout : Workout
    {
        public int HeartRate { get; set; } // average heart rate
        public double Distance { get; set; } // in km

        public CardioWorkout(int duration, DateTime date, UserProfile user, int heartRate, double distance)
            : base("Cardio", duration, date, user)
        {
            HeartRate = heartRate;
            Distance = distance;
        }

        public override void Track()
        {
            Console.WriteLine($"Tracking Cardio Workout: Duration {Duration} min, Heart Rate {HeartRate} bpm, Distance {Distance} km");
        }

        public override void DisplayWorkout()
        {
            base.DisplayWorkout();
            Console.WriteLine($"Heart Rate: {HeartRate} bpm, Distance: {Distance} km");
        }
    }
}
