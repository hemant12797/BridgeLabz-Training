using System;

class PrimeChecker
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        if (IsPrime(num))
            Console.WriteLine("Prime number");
        else
            Console.WriteLine("Not a prime number");
    }

    static bool IsPrime(int n)
    {
        if (n <= 1) return false;

        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0)
                return false;

        return true;
    }
}