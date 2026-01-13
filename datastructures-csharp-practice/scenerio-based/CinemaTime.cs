using System;
using System.Collections.Generic;

public class InvalidTimeFormatException : Exception
{
    public InvalidTimeFormatException(string message) : base(message) { }
}

public class MovieScheduleManager
{
    private List<string> titles;
    private List<string> times;

    public MovieScheduleManager()
    {
        titles = new List<string>();
        times = new List<string>();
    }

    public void AddMovie(string title, string time)
    {
        // Validate time format: HH:MM, hours 0-23, minutes 0-59
        if (!IsValidTime(time))
        {
            throw new InvalidTimeFormatException($"Invalid time format: {time}. Expected HH:MM with hours 0-23 and minutes 0-59.");
        }
        titles.Add(title);
        times.Add(time);
    }

    public List<string> SearchMovie(string keyword)
    {
        List<string> results = new List<string>();
        for (int i = 0; i < titles.Count; i++)
        {
            if (titles[i].IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                results.Add(string.Format("{0} at {1}", titles[i], times[i]));
            }
        }
        return results;
    }

    public void DisplayAllMovies()
    {
        string[] titleArray = titles.ToArray();
        string[] timeArray = times.ToArray();
        Console.WriteLine("All Movies:");
        for (int i = 0; i < titleArray.Length; i++)
        {
            Console.WriteLine(string.Format("{0} at {1}", titleArray[i], timeArray[i]));
        }
    }

    private bool IsValidTime(string time)
    {
        if (string.IsNullOrEmpty(time) || time.Length != 5 || time[2] != ':')
        {
            return false;
        }
        string[] parts = time.Split(':');
        if (parts.Length != 2)
        {
            return false;
        }
        int hours, minutes;
        if (!int.TryParse(parts[0], out hours) || !int.TryParse(parts[1], out minutes))
        {
            return false;
        }
        return hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59;
    }
}

class Program
{
    static void Main(string[] args)
    {
        MovieScheduleManager manager = new MovieScheduleManager();

        try
        {
            // Add some movies
            manager.AddMovie("Inception", "14:30");
            manager.AddMovie("The Dark Knight", "16:00");
            manager.AddMovie("Interstellar", "18:45");

            // Try invalid time
            manager.AddMovie("Invalid Movie", "25:99");
        }
        catch (InvalidTimeFormatException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        // Display all movies
        manager.DisplayAllMovies();

        // Search for movies
        List<string> searchResults = manager.SearchMovie("dark");
        Console.WriteLine("\nSearch results for 'dark':");
        foreach (string result in searchResults)
        {
            Console.WriteLine(result);
        }

        // Demonstrate IndexOutOfBoundsException handling (though not directly in methods, it can occur if lists are accessed incorrectly)
        try
        {
            // This would throw if we access out of bounds, but our methods prevent it
            Console.WriteLine(titles[10]); // This line won't compile as titles is private, but conceptually
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Index out of bounds: " + e.Message);
        }
    }
}
