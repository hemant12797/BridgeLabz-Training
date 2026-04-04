using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            string age = Console.ReadLine();
            Console.Write("Favorite Language: ");
            string lang = Console.ReadLine();

            using StreamWriter sw = new StreamWriter("user.txt");
            sw.WriteLine(name);
            sw.WriteLine(age);
            sw.WriteLine(lang);

            Console.WriteLine("Saved to user.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
