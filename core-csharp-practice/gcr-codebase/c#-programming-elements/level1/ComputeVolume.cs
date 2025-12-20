using System;

public class ComputeVolume
{
    public static void Main(String[] args)
    {
        double radius = 6378; // radius of earth is 6378 km
        double pi = Math.PI;

        double volumeinKm = (4/3) * pi * Math.Pow(radius , 3);

        // Convert km^3 to miles^3
        double kmToMiles = 0.621371;
        double volumeinMiles = volumeinKm * Math.Pow(kmToMiles, 3);

        Console.WriteLine("The volume of earth in cubic kilometers is "+ volumeinKm +" and cubic miles is "+ volumeinMiles);

    }
}