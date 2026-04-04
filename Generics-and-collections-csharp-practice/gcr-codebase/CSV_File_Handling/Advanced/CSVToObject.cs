
using System;
using System.Collections.Generic;
using System.IO;

class Student
{
    public int Id;
    public string Name;
    public int Age;
}

class CSVToObject
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        var lines = File.ReadAllLines("students.csv");

        for (int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split(',');
            students.Add(new Student
            {
                Id = int.Parse(data[0]),
                Name = data[1],
                Age = int.Parse(data[2])
            });
        }

        foreach (var s in students)
        {
            Console.WriteLine($"{s.Id} {s.Name} {s.Age}");
        }
    }
}
