using System;
class Human{}
class Ashish:Human{}
public class operatorsDemo{
    public static void Main(string[] args){

    int a = int.Parse(Console.ReadLine());
    int b = int.Parse(Console.ReadLine());

    // Arithmetic Operators -->
    Console.WriteLine("Addition: " + (a + b));
    Console.WriteLine("Subtraction: " + (a - b));
    Console.WriteLine("Multiplication: " + (a * b));
    Console.WriteLine("Division: " + (a / b)); 
    Console.WriteLine("Modulus: " + (a % b));

    // Relational Operators
    Console.WriteLine("a == b: " + (a == b)); 
    Console.WriteLine("a != b: " + (a != b)); 
    Console.WriteLine("a > b: " + (a > b)); 
    Console.WriteLine("a < b: " + (a < b)); 
    Console.WriteLine("a >= b: " + (a >= b));
    Console.WriteLine("a <= b: " + (a <= b));

    // Logical Operators
    bool x = true;
    bool y = false;
    Console.WriteLine("x && y: " + (x && y));
    Console.WriteLine("x || y: " + (x || y));
    Console.WriteLine("!x: " + (!x));
    Console.WriteLine("!y: " + (!y));

    // Assignment Operators
    a += b;
    Console.WriteLine("a += b: " + a);
    a -= b;
    Console.WriteLine("a -= b: " + a);
    a *= b;
    Console.WriteLine("a *= b: " + a);
    a /= b;
    Console.WriteLine("a /= b: " + a);
    a %= b;
    Console.WriteLine("a %= b: " + a);

    // Unary Operators
    a=5;
    Console.WriteLine("a: " + a);
    Console.WriteLine("++a: " + ++a);
    Console.WriteLine("a++: " + a++);
    Console.WriteLine("a: " + a);
    Console.WriteLine("--a: " + --a);
    Console.WriteLine("a--: " + a--);
    Console.WriteLine("a: " + a);

    // Bitwise Operators
    Console.WriteLine("a & b: " + (a & b));
    Console.WriteLine("a | b: " + (a | b));
    Console.WriteLine("a ^ b: " + (a ^ b));
    Console.WriteLine("~a: " + (~a));
    Console.WriteLine("a << 1: " + (a << 1));
    Console.WriteLine("a >> 1: " + (a >> 1));

    // Ternary Operator
    int max = (a > b) ? a : b;
    Console.WriteLine("Max: " + max);

    // is Operator
    Human Ashish = new Ashish(); 
    Console.WriteLine("Ashish is Human " + (Ashish is Human));
    Console.WriteLine("Ashish is Ashish "+ (Ashish is Ashish));
    Console.WriteLine("Ashish is Integer "+ (Ashish is int));

}
}