using System;

class FactorsAnalysis
{
    static int[] GetFactors(int n)
    {
        int count = 0;
        for (int i = 1; i <= n; i++)
            if (n % i == 0) count++;

        int[] f = new int[count];
        int index = 0;
        for (int i = 1; i <= n; i++)
            if (n % i == 0) f[index++] = i;

        return f;
    }

    static int Sum(int[] a)
    {
        int s = 0;
        foreach (int x in a) s += x;
        return s;
    }

    static long Product(int[] a)
    {
        long p = 1;
        foreach (int x in a) p *= x;
        return p;
    }

    static double SumOfSquares(int[] a)
    {
        double s = 0;
        foreach (int x in a) s += Math.Pow(x, 2);
        return s;
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] f = GetFactors(n);

        foreach (int x in f) Console.Write(x + " ");
        Console.WriteLine();
        Console.WriteLine(Sum(f));
        Console.WriteLine(Product(f));
        Console.WriteLine(SumOfSquares(f));
    }
}