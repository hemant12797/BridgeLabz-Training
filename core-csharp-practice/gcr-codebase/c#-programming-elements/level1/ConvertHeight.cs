using System;

public class ConvertHeight
{
    public static void Main(String[] args)
    {
        Console.Write("Enter distance in cms :");
        float distanceincms = float.Parse(Console.ReadLine());

        // 1 foot = 12 inches and 1 inch = 2.54 cm
        float inches = distanceincms / 2.54f;
        int feet = (int)inches / 12;
        inches = inches % 12;
        Console.WriteLine("Your Height in cm is "+ distanceincms +" while in feet is "+ feet +" and inches is "+ inches);
    }
}