using System;

class GcdLcmCalculator
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        int gcd = GCD(a, b);
        int lcm = (a * b) / gcd;

        Console.WriteLine("GCD: " + gcd);
        Console.WriteLine("LCM: " + lcm);
    }

    static int GCD(int x, int y)
    {
        while (y != 0)
        {
            int temp = y;
            y = x % y;
            x = temp;
        }
        return x;
    }
}