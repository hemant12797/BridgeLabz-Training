
using System;
using System.IO;

class CountRows
{
    static void Main()
    {
        int count = File.ReadAllLines("data.csv").Length - 1;
        Console.WriteLine($"Total Records: {count}");
    }
}
