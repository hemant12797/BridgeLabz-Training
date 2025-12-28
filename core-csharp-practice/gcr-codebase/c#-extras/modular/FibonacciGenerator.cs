using System;

class FibonacciGenerator
{
    static void Main()
    {
        Console.Write("Enter number of terms: ");
        int n = int.Parse(Console.ReadLine());

        PrintFibonacci(n);
    }

    static void PrintFibonacci(int terms)
    {
        int a = 0, b = 1;

        for (int i = 0; i < terms; i++)
        {
            Console.Write(a + " ");
            int temp = a + b;
            a = b;
            b = temp;
        }
    }
}