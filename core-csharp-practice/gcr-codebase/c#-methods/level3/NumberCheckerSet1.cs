using System;

class NumberCheckerSet1
{
    static int[] Digits(int n)
    {
        int[] d = new int[n.ToString().Length];
        for (int i = 0; i < d.Length; i++) { d[i] = n % 10; n /= 10; }
        return d;
    }

    static bool Duck(int[] d)
    {
        foreach (int x in d) if (x != 0) return true;
        return false;
    }

    static bool Armstrong(int n, int[] d)
    {
        int s = 0;
        foreach (int x in d) s += (int)Math.Pow(x, d.Length);
        return s == n;
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] d = Digits(n);
        Console.WriteLine(Duck(d));
        Console.WriteLine(Armstrong(n, d));
    }
}