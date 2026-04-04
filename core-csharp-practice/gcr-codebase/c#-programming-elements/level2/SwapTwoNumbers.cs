using System;

public class SwapTwoNumbers
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter first number :");
        int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number :");
        int num2 = int.Parse(Console.ReadLine());

        int temp = num1;
        num1 = num2;
        num2 = temp;

        Console.WriteLine("The swapped numbers are "+ num1 +" and "+ num2);

    }
}