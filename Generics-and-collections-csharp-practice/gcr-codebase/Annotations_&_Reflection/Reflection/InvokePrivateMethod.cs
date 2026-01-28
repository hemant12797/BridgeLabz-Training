using System;
using System.Reflection;

class Calculator
{
    private int Multiply(int a, int b)
    {
        return a * b;
    }
}

class InvokePrivateMethod
{
    static void Main()
    {
        Calculator c = new Calculator();
        MethodInfo method = typeof(Calculator)
            .GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);

        object result = method.Invoke(c, new object[] { 5, 6 });
        Console.WriteLine("Result: " + result);
    }
}