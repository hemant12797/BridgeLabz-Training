using System;

class UnitConverterSet1
{
    static double KmToMiles(double km) { return km * 0.621371; }
    static double MilesToKm(double m) { return m * 1.60934; }
    static double MetersToFeet(double m) { return m * 3.28084; }
    static double FeetToMeters(double f) { return f * 0.3048; }

    static void Main()
    {
        double v = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(KmToMiles(v));
        Console.WriteLine(MilesToKm(v));
        Console.WriteLine(MetersToFeet(v));
        Console.WriteLine(FeetToMeters(v));
    }
}