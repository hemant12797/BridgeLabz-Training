using System;

public class DoubleOperation
{
    public  static void Main(String[] args)
    {
        Console.WriteLine("Enter first number :");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number :");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter third number :");
        double c = double.Parse(Console.ReadLine());

        double operation1 = a + b * c;
        double operation2 = a * b + c;
        double operation3 = c + a / b;
        double operation4 = a % b + c;

        Console.WriteLine("The results of Int Operations are "+ operation1 +" , "+ operation2 +" , "+ operation3+ " and "+ operation4);

    }
}