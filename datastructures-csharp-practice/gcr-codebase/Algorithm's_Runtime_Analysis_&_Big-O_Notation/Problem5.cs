using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int[] ns = { 10, 30, 50 };

        foreach (int n in ns)
        {
            // Recursive
            Stopwatch sw = Stopwatch.StartNew();
            int recResult = FibonacciRecursive(n);
            sw.Stop();
            Console.WriteLine($"Recursive Fibonacci({n}): {sw.ElapsedMilliseconds} ms, Result: {recResult}");

            // Iterative
            sw.Restart();
            int iterResult = FibonacciIterative(n);
            sw.Stop();
            Console.WriteLine($"Iterative Fibonacci({n}): {sw.ElapsedMilliseconds} ms, Result: {iterResult}");
        }
    }

    static int FibonacciRecursive(int n)
    {
        if (n <= 1) return n;
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    static int FibonacciIterative(int n)
    {
        if (n <= 1) return n;
        int a = 0, b = 1, sum = 0;
        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }
        return b;
    }
}
