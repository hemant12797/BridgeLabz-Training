using System;

public class Calculator
{
    public static void Main(String[] args)
    {
        Console.Write("Enter fisrt number: ");
        float num1 = float.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("Enter second number: ");
        Console.WriteLine();
        float num2 = float.Parse(Console.ReadLine());

        float addition = num1 + num2;
        float substruction = num1 - num2;
        float multiplication = num1 * num2;
        float division = num1 / num2;

        Console.WriteLine("The addition, subtraction, multiplication and division value of given numbers "
        + num1 +" and "+ num2 +"is "+addition+","+substruction+","+multiplication+","+division);

    }
}