using System;

class MathUtility
{
    // Method to calculate factorial
    public static long Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentException("Factorial is not defined for negative numbers.");

        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    // Method to check if a number is prime
    public static bool IsPrime(int n)
    {
        if (n <= 1)
            return false;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    // Method to find GCD using Euclidean Algorithm
    public static int GCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Method to find nth Fibonacci number
    public static long Fibonacci(int n)
    {
        if (n < 0)
            throw new ArgumentException("Fibonacci is not defined for negative numbers.");

        if (n == 0) return 0;
        if (n == 1) return 1;

        long a = 0, b = 1, c = 0;

        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }
}

class Program
{
    static void Main()
    {
        // Testing Factorial
        Console.WriteLine("Factorial Tests:");
        Console.WriteLine("Factorial(5): " + MathUtility.Factorial(5));
        Console.WriteLine("Factorial(0): " + MathUtility.Factorial(0));

        // Testing Prime Check
        Console.WriteLine("\nPrime Tests:");
        Console.WriteLine("IsPrime(7): " + MathUtility.IsPrime(7));
        Console.WriteLine("IsPrime(1): " + MathUtility.IsPrime(1));
        Console.WriteLine("IsPrime(-5): " + MathUtility.IsPrime(-5));

        // Testing GCD
        Console.WriteLine("\nGCD Tests:");
        Console.WriteLine("GCD(48, 18): " + MathUtility.GCD(48, 18));
        Console.WriteLine("GCD(-10, 5): " + MathUtility.GCD(-10, 5));

        // Testing Fibonacci
        Console.WriteLine("\nFibonacci Tests:");
        Console.WriteLine("Fibonacci(0): " + MathUtility.Fibonacci(0));
        Console.WriteLine("Fibonacci(1): " + MathUtility.Fibonacci(1));
        Console.WriteLine("Fibonacci(10): " + MathUtility.Fibonacci(10));
    }
}
