using System;

class Quadratic
{
    static double[] Roots(double a, double b, double c)
    {
        double d = b * b - 4 * a * c;
        if (d < 0) return new double[0];
        if (d == 0) return new double[] { -b / (2 * a) };

        double r1 = (-b + Math.Sqrt(d)) / (2 * a);
        double r2 = (-b - Math.Sqrt(d)) / (2 * a);
        return new double[] { r1, r2 };
    }

    static void Main()
    {
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());

        double[] r = Roots(a, b, c);
        foreach (double x in r) Console.WriteLine(x);
    }
}