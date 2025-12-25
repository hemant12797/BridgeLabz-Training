using System;

class Trigonometry
{
    static double[] Calculate(double angle)
    {
        double rad = angle * Math.PI / 180;
        return new double[] { Math.Sin(rad), Math.Cos(rad), Math.Tan(rad) };
    }

    static void Main()
    {
        double a = Convert.ToDouble(Console.ReadLine());
        double[] r = Calculate(a);
        Console.WriteLine(r[0]);
        Console.WriteLine(r[1]);
        Console.WriteLine(r[2]);
    }
}