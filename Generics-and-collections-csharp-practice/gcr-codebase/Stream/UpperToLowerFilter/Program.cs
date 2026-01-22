using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Source file: ");
        string src = Console.ReadLine();
        Console.Write("Destination file: ");
        string dest = Console.ReadLine();

        using StreamReader sr = new StreamReader(src, Encoding.UTF8);
        using StreamWriter sw = new StreamWriter(dest, false, Encoding.UTF8);

        string line;
        while ((line = sr.ReadLine()) != null)
            sw.WriteLine(line.ToLower());

        Console.WriteLine("Done");
    }
}
