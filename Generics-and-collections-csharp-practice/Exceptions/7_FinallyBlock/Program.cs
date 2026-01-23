using System;

class Program {
    static void Main() {
        try {
            int a = 10, b = 0;
            Console.WriteLine(a / b);
        } catch (DivideByZeroException) {
            Console.WriteLine("Division by zero");
        } finally {
            Console.WriteLine("Operation completed");
        }
    }
}