using System;

public class IntOperation
{
    public  static void Main(String[] args)
    {
        Console.WriteLine("Enter first number :");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number :");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter third number :");
        int c = int.Parse(Console.ReadLine());

        int operation1 = a + b * c;
        int operation2 = a * b + c;
        int operation3 = c + a / b;
        int operation4 = a % b + c;

        Console.WriteLine("The results of Int Operations are "+ operation1 +" , "+ operation2 +" , "+ operation3+ " and "+ operation4);

    }
}