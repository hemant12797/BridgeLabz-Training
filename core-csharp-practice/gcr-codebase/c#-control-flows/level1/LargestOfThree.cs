using System;

public class LargestOfThree
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the first number: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second number: ");
        int num2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the third number: ");
        int num3 = int.Parse(Console.ReadLine());

        Console.WriteLine("Is the first number the largest? "+((num1 > num2) && (num1 > num3)));
        Console.WriteLine("Is the Second number the largest? "+((num2 > num1) && (num2 > num3)));
        Console.WriteLine("Is the Third number the largest? "+((num3 > num2) && (num3 > num1)));

    }
}