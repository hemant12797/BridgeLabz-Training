using System;

class SimpleInterest
{
    static double Calculate(double p, double r, double t)
    {
        return (p * r * t) / 100;
    }

    static void Main()
    {
        double p = Convert.ToDouble(Console.ReadLine());
        double r = Convert.ToDouble(Console.ReadLine());
        double t = Convert.ToDouble(Console.ReadLine());

        double si = Calculate(p, r, t);
        Console.WriteLine($"The Simple Interest is {si} for Principal {p}, Rate of Interest {r} and Time {t}");
    }
}