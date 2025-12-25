using System;

class CollinearPoints
{
    static void Main()
    {
        double x1 = 2, y1 = 4, x2 = 4, y2 = 6, x3 = 6, y3 = 8;

        double area = 0.5 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
        Console.WriteLine(area == 0);
    }
}