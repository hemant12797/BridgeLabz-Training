
using System.IO;
using System.Text.Json;

class JsonCsv
{
    static void Main()
    {
        string json = File.ReadAllText("students.json");
        var students = JsonSerializer.Deserialize<dynamic[]>(json);

        using StreamWriter writer = new StreamWriter("students.csv");
        writer.WriteLine("ID,Name,Age");

        foreach (var s in students)
        {
            writer.WriteLine($"{s.Id},{s.Name},{s.Age}");
        }
    }
}
