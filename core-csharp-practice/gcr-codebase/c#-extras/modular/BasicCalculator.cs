using System;

class BasicCalculator
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Choose operation (+ - * /): ");
        char op = Console.ReadLine()[0];

        Console.WriteLine("Result: " + Calculate(a, b, op));
    }

    static double Calculate(double x, double y, char op)
    {
        switch (op)
        {
            case '+': return x + y;
            case '-': return x - y;
            case '*': return x * y;
            case '/': return x / y;
            default: return 0;
        }
    }
}