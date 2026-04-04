using System;

class InvalidAgeException : Exception {}

class Program {
    static void ValidateAge(int age) {
        if (age < 18) throw new InvalidAgeException();
    }

    static void Main() {
        try {
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            ValidateAge(age);
            Console.WriteLine("Access granted!");
        } catch (InvalidAgeException) {
            Console.WriteLine("Age must be 18 or above");
        }
    }
}