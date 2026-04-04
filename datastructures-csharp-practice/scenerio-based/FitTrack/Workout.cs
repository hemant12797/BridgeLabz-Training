using System;

namespace FitTrack
{
    public abstract class Workout : ITrackable
    {
        public string Type { get; set; }
        public int Duration { get; set; } // in minutes
        public DateTime Date { get; set; }
        public UserProfile User { get; set; }

        public Workout(string type, int duration, DateTime date, UserProfile user)
        {
            Type = type;
            Duration = duration;
            Date = date;
            User = user;
        }

        public abstract void Track();

        public virtual void DisplayWorkout()
        {
            Console.WriteLine($"Workout Type: {Type}, Duration: {Duration} minutes, Date: {Date.ToShortDateString()}");
        }
    }
}
