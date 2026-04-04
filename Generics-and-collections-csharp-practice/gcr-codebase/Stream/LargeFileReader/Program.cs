using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("File path: ");
        string path = Console.ReadLine();

        using StreamReader sr = new StreamReader(path);
        string line;
        while ((line = sr.ReadLine()) != null)
            if (line.Contains("error", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine(line);
    }
}
