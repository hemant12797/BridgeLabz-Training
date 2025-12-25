using System;

class NumberCheckerSet3
{
    static int[] Digits(int n)
    {
        int[] d = new int[n.ToString().Length];
        for (int i = 0; i < d.Length; i++) { d[i] = n % 10; n /= 10; }
        return d;
    }

    static int[] Reverse(int[] d)
    {
        int[] r = new int[d.Length];
        for (int i = 0; i < d.Length; i++) r[i] = d[d.Length - 1 - i];
        return r;
    }

    static bool Equal(int[] a, int[] b)
    {
        if (a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++) if (a[i] != b[i]) return false;
        return true;
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] d = Digits(n);
        Console.WriteLine(Equal(d, Reverse(d)));
    }
}