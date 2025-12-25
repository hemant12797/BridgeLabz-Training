using System;

class FootballHeights
{
    static int Sum(int[] h)
    {
        int s = 0;
        for (int i = 0; i < h.Length; i++) s += h[i];
        return s;
    }

    static double Mean(int[] h)
    {
        return (double)Sum(h) / h.Length;
    }

    static int Shortest(int[] h)
    {
        int m = h[0];
        for (int i = 1; i < h.Length; i++) if (h[i] < m) m = h[i];
        return m;
    }

    static int Tallest(int[] h)
    {
        int m = h[0];
        for (int i = 1; i < h.Length; i++) if (h[i] > m) m = h[i];
        return m;
    }

    static void Main()
    {
        int[] heights = new int[11];
        Random r = new Random();
        for (int i = 0; i < heights.Length; i++) heights[i] = r.Next(150, 251);

        Console.WriteLine("Mean: " + Mean(heights));
        Console.WriteLine("Shortest: " + Shortest(heights));
        Console.WriteLine("Tallest: " + Tallest(heights));
    }
}