using System;

namespace FitTrack
{
    public class StrengthWorkout : Workout
    {
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; } // in kg

        public StrengthWorkout(int duration, DateTime date, UserProfile user, int sets, int reps, double weight)
            : base("Strength", duration, date, user)
        {
            Sets = sets;
            Reps = reps;
            Weight = weight;
        }

        public override void Track()
        {
            Console.WriteLine($"Tracking Strength Workout: Duration {Duration} min, Sets {Sets}, Reps {Reps}, Weight {Weight} kg");
        }

        public override void DisplayWorkout()
        {
            base.DisplayWorkout();
            Console.WriteLine($"Sets: {Sets}, Reps: {Reps}, Weight: {Weight} kg");
        }
    }
}
