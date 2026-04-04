using System;

class YoungestTallestFriends
{
    static int Youngest(int[] a)
    {
        int m = a[0];
        for (int i = 1; i < a.Length; i++) if (a[i] < m) m = a[i];
        return m;
    }

    static double Tallest(double[] h)
    {
        double m = h[0];
        for (int i = 1; i < h.Length; i++) if (h[i] > m) m = h[i];
        return m;
    }

    static void Main()
    {
        int[] age = new int[3];
        double[] height = new double[3];

        for (int i = 0; i < 3; i++)
        {
            age[i] = Convert.ToInt32(Console.ReadLine());
            height[i] = Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine(Youngest(age));
        Console.WriteLine(Tallest(height));
    }
}