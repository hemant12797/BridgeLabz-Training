using System;

public class SmallestOfThreeNumber
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the first number: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second number: ");
        int num2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the third number: ");
        int num3 = int.Parse(Console.ReadLine());

        Console.WriteLine("Is the first number the smallest? " + ((num1 < num2) && (num1 < num3)));

    }
}