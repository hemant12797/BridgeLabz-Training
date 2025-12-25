using System;

class ZaraBonus2D
{
    static void Main()
    {
        double[,] emp = new double[10,2];
        double[,] result = new double[10,2];
        Random r = new Random();

        for (int i = 0; i < 10; i++)
        {
            emp[i,0] = r.Next(10000,99999);
            emp[i,1] = r.Next(1,11);
        }

        for (int i = 0; i < 10; i++)
        {
            double bonus = emp[i,1] > 5 ? emp[i,0] * 0.05 : emp[i,0] * 0.02;
            result[i,0] = emp[i,0] + bonus;
            result[i,1] = bonus;
        }

        Console.WriteLine("Done");
    }
}