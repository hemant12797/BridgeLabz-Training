using System;

public class FeetToMiles
{
    public static void Main(String[] args)
    {
        Console.Write("Enter the number of feet: ");
        float feet = float.Parse(Console.ReadLine());

        float yards = feet / 3; // 1 yard = 3 feet
        float miles = yards / 1760; // 1 mile = 1760 yards


        Console.WriteLine("Your Height in feet is "+ feet +" while in miles is "+ miles);

    }
}