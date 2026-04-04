using System;

class NumberCheckerSet4
{
    static bool Prime(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++) if (n % i == 0) return false;
        return true;
    }

    static bool Buzz(int n)
    {
        return n % 7 == 0 || n % 10 == 7;
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Prime(n));
        Console.WriteLine(Buzz(n));
    }
}