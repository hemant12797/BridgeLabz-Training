using System;

class RecursiveSum
{
    static int Recursive(int n)
    {
        if (n == 0) return 0;
        return n + Recursive(n - 1);
    }

    static int Formula(int n)
    {
        return n * (n + 1) / 2;
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        if (n <= 0) return;

        int r1 = Recursive(n);
        int r2 = Formula(n);

        Console.WriteLine(r1);
        Console.WriteLine(r2);
        Console.WriteLine(r1 == r2);
    }
}