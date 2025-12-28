using System;

class FactorialRecursion
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine("Factorial: " + Factorial(num));
    }

    static long Factorial(int n)
    {
        if (n == 0) return 1;
        return n * Factorial(n - 1);
    }
}