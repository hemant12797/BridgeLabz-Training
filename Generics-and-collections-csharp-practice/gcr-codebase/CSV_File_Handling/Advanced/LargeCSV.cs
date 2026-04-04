
using System;
using System.IO;

class LargeCSV
{
    static void Main()
    {
        int count = 0;

        using StreamReader reader = new StreamReader("large.csv");

        while (!reader.EndOfStream)
        {
            for (int i = 0; i < 100 && !reader.EndOfStream; i++)
            {
                reader.ReadLine();
                count++;
            }

            Console.WriteLine($"Processed Records: {count}");
        }
    }
}
