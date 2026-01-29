
using System;
using System.IO;
using System.Linq;

class DuplicateDetect
{
    static void Main()
    {
        var duplicates =
            File.ReadAllLines("data.csv")
                .Skip(1)
                .Select(l => l.Split(',')[0])
                .GroupBy(id => id)
                .Where(g => g.Count() > 1);

        foreach (var d in duplicates)
        {
            Console.WriteLine("Duplicate ID: " + d.Key);
        }
    }
}
