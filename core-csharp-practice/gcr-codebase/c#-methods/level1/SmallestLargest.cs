using System;

class SmallestLargest
{
    static int[] FindSmallestAndLargest(int a, int b, int c)
    {
        int min = a, max = a;
        if (b < min) min = b;
        if (c < min) min = c;
        if (b > max) max = b;
        if (c > max) max = c;
        return new int[] { min, max };
    }

    static void Main()
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());

        int[] r = FindSmallestAndLargest(a, b, c);
        Console.WriteLine(r[0] + " " + r[1]);
    }
}