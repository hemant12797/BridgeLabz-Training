using System;

class NumberCheckerSet2
{
    static int[] Digits(int n)
    {
        int[] d = new int[n.ToString().Length];
        for (int i = 0; i < d.Length; i++) { d[i] = n % 10; n /= 10; }
        return d;
    }

    static int SumDigits(int[] d)
    {
        int s = 0;
        foreach (int x in d) s += x;
        return s;
    }

    static bool Harshad(int n, int[] d)
    {
        return n % SumDigits(d) == 0;
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] d = Digits(n);
        Console.WriteLine(Harshad(n, d));
    }
}