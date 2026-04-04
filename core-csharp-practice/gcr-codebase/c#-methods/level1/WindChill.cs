using System;

class WindChill
{
    static double Calculate(double t, double v)
    {
        return 35.74 + 0.6215 * t + (0.4275 * t - 35.75) * Math.Pow(v, 0.16);
    }

    static void Main()
    {
        double t = Convert.ToDouble(Console.ReadLine());
        double v = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(Calculate(t, v));
    }
}