using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("File path: ");
        string path = Console.ReadLine();

        Dictionary<string, int> map = new();
        using StreamReader sr = new StreamReader(path);
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            foreach (var w in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                string word = w.ToLower();
                map[word] = map.ContainsKey(word) ? map[word] + 1 : 1;
            }
        }

        foreach (var kv in map.OrderByDescending(x => x.Value).Take(5))
            Console.WriteLine($"{kv.Key} : {kv.Value}");
    }
}
