using System;
using System.Reflection;

class MathOperations
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;
}

class DynamicMethodInvocation
{
    static void Main()
    {
        MathOperations m = new MathOperations();
        Console.Write("Enter method name: ");
        string name = Console.ReadLine();

        MethodInfo method = typeof(MathOperations).GetMethod(name);
        object result = method.Invoke(m, new object[] { 10, 5 });

        Console.WriteLine("Result: " + result);
    }
}