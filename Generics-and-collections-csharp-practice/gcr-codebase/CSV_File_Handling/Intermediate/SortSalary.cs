
using System;
using System.IO;
using System.Linq;

class SortSalary
{
    static void Main()
    {
        var records = File.ReadAllLines("employees.csv")
                          .Skip(1)
                          .Select(l => l.Split(','))
                          .OrderByDescending(d => int.Parse(d[3]))
                          .Take(5);

        foreach (var emp in records)
        {
            Console.WriteLine(string.Join(",", emp));
        }
    }
}
