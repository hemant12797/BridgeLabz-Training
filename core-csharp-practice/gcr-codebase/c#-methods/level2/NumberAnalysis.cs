using System;

class NumberAnalysis
{
    static bool IsPositive(int n) { return n > 0; }
    static bool IsEven(int n) { return n % 2 == 0; }

    static int Compare(int a, int b)
    {
        if (a > b) return 1;
        if (a < b) return -1;
        return 0;
    }

    static void Main()
    {
        int[] n = new int[5];
        for (int i = 0; i < n.Length; i++)
        {
            n[i] = Convert.ToInt32(Console.ReadLine());
            if (IsPositive(n[i]))
                Console.WriteLine(IsEven(n[i]));
            else
                Console.WriteLine("Negative");
        }

        Console.WriteLine(Compare(n[0], n[4]));
    }
}