using System;

class FactorsAnalysis
{
    static int[] Factors(int n)
    {
        int c = 0;
        for (int i = 1; i <= n; i++) if (n % i == 0) c++;
        int[] f = new int[c];
        int k = 0;
        for (int i = 1; i <= n; i++) if (n % i == 0) f[k++] = i;
        return f;
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] f = Factors(n);
        foreach (int x in f) Console.Write(x + " ");
    }
}