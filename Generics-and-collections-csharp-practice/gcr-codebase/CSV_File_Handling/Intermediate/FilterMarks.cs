
using System;
using System.IO;

class FilterMarks
{
    static void Main()
    {
        var lines = File.ReadAllLines("students.csv");

        for (int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split(',');
            if (int.Parse(data[3]) > 80)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}
