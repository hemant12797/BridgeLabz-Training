using System;

class ChocolatesDistribution
{
    static int[] FindRemainderAndQuotient(int c, int k)
    {
        return new int[] { c / k, c % k };
    }

    static void Main()
    {
        int chocolates = Convert.ToInt32(Console.ReadLine());
        int children = Convert.ToInt32(Console.ReadLine());

        int[] r = FindRemainderAndQuotient(chocolates, children);
        Console.WriteLine(r[0] + " " + r[1]);
    }
}