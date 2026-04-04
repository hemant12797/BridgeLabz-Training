using System;

class SumOfNaturals
{
    static int Sum(int n)
    {
        int s = 0;
        for (int i = 1; i <= n; i++) s += i;
        return s;
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Sum(n));
    }
}