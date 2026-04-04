using System;

public class Divide
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter first number : ");
        int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number : ");
        int num2 = int.Parse(Console.ReadLine());

        // Using division operator (/) for quotient and modulus operator (%) for remainder

        int quotient = num1 / num2;
        int remainder = num1 % num2;

        Console.WriteLine("The Quotient is "+quotient+" and Remainder is "+remainder+" of two numbers "+num1+" and "+num2+"");

    }
}