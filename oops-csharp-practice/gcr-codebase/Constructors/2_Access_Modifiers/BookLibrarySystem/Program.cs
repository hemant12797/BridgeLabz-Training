
using System;
class Program
{
    static void Main()
    {
        EBook b = new EBook();
        b.ISBN = "12345";
        b.SetAuthor("Ashish");
        Console.WriteLine(b.GetAuthor());
    }
}
