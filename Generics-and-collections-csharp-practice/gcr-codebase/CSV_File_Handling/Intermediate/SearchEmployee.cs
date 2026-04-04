
using System;
using System.IO;

class SearchEmployee
{
    static void Main()
    {
        var lines = File.ReadAllLines("employees.csv");

        foreach (var line in lines)
        {
            var data = line.Split(',');
            if (data[1] == "Amit")
            {
                Console.WriteLine(
                    $"Department: {data[2]}, Salary: {data[3]}");
            }
        }
    }
}
