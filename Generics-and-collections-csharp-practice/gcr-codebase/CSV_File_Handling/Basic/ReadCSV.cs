
using System;
using System.IO;

class ReadCSV
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("students.csv");

        for (int i = 1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(',');
            Console.WriteLine(
                $"ID: {data[0]}, Name: {data[1]}, Age: {data[2]}, Marks: {data[3]}");
        }
    }
}
