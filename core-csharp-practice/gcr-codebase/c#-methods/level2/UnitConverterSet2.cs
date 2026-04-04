using System;

class UnitConverterSet2
{
    static double YardsToFeet(double y) { return y * 3; }
    static double FeetToYards(double f) { return f * 0.333333; }
    static double MetersToInches(double m) { return m * 39.3701; }
    static double InchesToMeters(double i) { return i * 0.0254; }
    static double InchesToCm(double i) { return i * 2.54; }

    static void Main()
    {
        double v = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(YardsToFeet(v));
        Console.WriteLine(FeetToYards(v));
        Console.WriteLine(MetersToInches(v));
        Console.WriteLine(InchesToMeters(v));
        Console.WriteLine(InchesToCm(v));
    }
}