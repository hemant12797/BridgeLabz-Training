using System;

class Program
{
    static void Main()
    {
        Person p1 = new Person("Ashish", 22);
        Person p2 = new Person(p1);
        Console.WriteLine(p2.Name + " " + p2.Age);
    }
}
