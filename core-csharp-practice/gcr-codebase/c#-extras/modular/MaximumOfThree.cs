using System;

class MaximumOfThree
{
    static void Main()
    {
        int a = GetInput("Enter first number: ");
        int b = GetInput("Enter second number: ");
        int c = GetInput("Enter third number: ");

        int max = FindMaximum(a, b, c);
        Console.WriteLine("Maximum number is: " + max);
    }

    static int GetInput(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }

    static int FindMaximum(int x, int y, int z)
    {
        return Math.Max(x, Math.Max(y, z));
    }
}