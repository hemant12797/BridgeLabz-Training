using System;

public class kmToMiles
{
    public static void Main(String[] args)
    {
        Console.Write("Enter distance in kilometers: ");
        float km = float.Parse(Console.ReadLine());

        float miles = km / 1.6f; // 1 mile = 1.6 km

        Console.WriteLine("The total miles is "+ miles +" mile for the given "+km +" km");

    }
}