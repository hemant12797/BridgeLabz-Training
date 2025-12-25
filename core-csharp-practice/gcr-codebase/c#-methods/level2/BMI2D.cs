using System;

class BMI2D
{
    static double[,] Calculate(double[,] d)
    {
        for (int i = 0; i < 10; i++)
        {
            double h = d[i,1] / 100;
            d[i,2] = d[i,0] / (h * h);
        }
        return d;
    }

    static void Main()
    {
        double[,] p = new double[10,3];
        for (int i = 0; i < 10; i++)
        {
            p[i,0] = Convert.ToDouble(Console.ReadLine());
            p[i,1] = Convert.ToDouble(Console.ReadLine());
        }

        Calculate(p);

        for (int i = 0; i < 10; i++)
            Console.WriteLine(p[i,2]);
    }
}