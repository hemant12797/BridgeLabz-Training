using System;

class Program {
    static void Method1() {
        int x = 10 / 0;
    }

    static void Method2() {
        Method1();
    }

    static void Main() {
        try {
            Method2();
        } catch (ArithmeticException) {
            Console.WriteLine("Handled exception in Main");
        }
    }
}