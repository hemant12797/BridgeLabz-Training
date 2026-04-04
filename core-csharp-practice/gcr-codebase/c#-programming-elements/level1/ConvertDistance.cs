using System;

public class ConvertDistance
{
    public static void Main(String[] args)
    {
        float distanceInKms = 10.6f;
        float distanceInMiles  = distanceInKms / 1.6f; // 1km = 1.6miles

        Console.WriteLine("The distance "+ distanceInKms +" in miles is "+ distanceInMiles);
    }
}