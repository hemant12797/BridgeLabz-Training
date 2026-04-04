using System;

class NumberSign
{
    static int Check(int n)
    {
        if (n > 0) return 1;
        if (n < 0) return -1;
        return 0;
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Check(n));
    }
}