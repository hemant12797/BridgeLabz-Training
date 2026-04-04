using System;

class Program
{
    static void Main()
    {
        Book b1 = new Book();
        Book b2 = new Book("C# Basics", "Ashish", 499);
        Console.WriteLine(b2.Title + " " + b2.Author + " " + b2.Price);
    }
}
