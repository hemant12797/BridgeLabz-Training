using System;

class DistanceAndLine
{
    static void Main()
    {
        double x1 = Convert.ToDouble(Console.ReadLine());
        double y1 = Convert.ToDouble(Console.ReadLine());
        double x2 = Convert.ToDouble(Console.ReadLine());
        double y2 = Convert.ToDouble(Console.ReadLine());

        double dist = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        double m = (y2 - y1) / (x2 - x1);
        double b = y1 - m * x1;

        Console.WriteLine(dist);
        Console.WriteLine(m + " " + b);
    }
}