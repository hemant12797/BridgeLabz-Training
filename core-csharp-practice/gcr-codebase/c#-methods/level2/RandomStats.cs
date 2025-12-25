using System;

class RandomStats
{
    static int[] Generate(int size)
    {
        Random r = new Random();
        int[] a = new int[size];
        for (int i = 0; i < size; i++)
            a[i] = r.Next(1000, 9999);
        return a;
    }

    static double[] Analyze(int[] a)
    {
        int min = a[0], max = a[0], sum = 0;
        foreach (int x in a)
        {
            sum += x;
            min = Math.Min(min, x);
            max = Math.Max(max, x);
        }
        return new double[] { (double)sum / a.Length, min, max };
    }

    static void Main()
    {
        int[] a = Generate(5);
        double[] r = Analyze(a);

        Console.WriteLine(r[0]);
        Console.WriteLine(r[1]);
        Console.WriteLine(r[2]);
    }
}