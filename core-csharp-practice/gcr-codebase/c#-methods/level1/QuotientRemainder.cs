using System;

class QuotientRemainder
{
    static int[] FindRemainderAndQuotient(int n, int d)
    {
        return new int[] { n / d, n % d };
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int d = Convert.ToInt32(Console.ReadLine());

        int[] r = FindRemainderAndQuotient(n, d);
        Console.WriteLine(r[0] + " " + r[1]);
    }
}