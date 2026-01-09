using System;
using System.Collections.Generic;

namespace FitTrack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a user profile
            UserProfile user = new UserProfile("John Doe", 30, 75.0, 180.0);

            // Create workouts
            CardioWorkout cardio = new CardioWorkout(45, DateTime.Now, user, 150, 5.0);
            StrengthWorkout strength = new StrengthWorkout(60, DateTime.Now.AddDays(-1), user, 3, 10, 50.0);

            // List of workouts
            List<Workout> workouts = new List<Workout> { cardio, strength };

            // Display user profile
            Console.WriteLine("User Profile:");
            user.DisplayProfile();
            Console.WriteLine();

            // Display and track workouts
            Console.WriteLine("Workouts:");
            foreach (var workout in workouts)
            {
                workout.DisplayWorkout();
                workout.Track();
                Console.WriteLine();
            }
        }
    }
}
