using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        JsonObject studentJson = new JsonObject
        {
            ["name"] = "Gaurav",
            ["age"] = 22,
            ["subjects"] = new JsonArray("Math", "CS", "Networks")
        };
        Console.WriteLine(studentJson.ToJsonString());

        Car car = new Car { Brand = "Tesla", Year = 2024 };
        string carJson = JsonSerializer.Serialize(car);
        Console.WriteLine(carJson);

        File.WriteAllText("user.json",
        @"{ ""name"": ""Alice"", ""email"": ""alice@gmail.com"", ""age"": 30 }");

        JsonDocument doc = JsonDocument.Parse(File.ReadAllText("user.json"));
        Console.WriteLine(
            doc.RootElement.GetProperty("name").GetString() + " " +
            doc.RootElement.GetProperty("email").GetString()
        );

        JsonObject a = JsonNode.Parse(@"{ ""name"": ""John"" }").AsObject();
        JsonObject b = JsonNode.Parse(@"{ ""email"": ""john@mail.com"" }").AsObject();
        foreach (var x in b)
        {
            a[x.Key] = x.Value?.DeepClone();
        }
        Console.WriteLine(a.ToJsonString());

        string json = @"{ ""name"": ""Sam"", ""age"": 20 }";
        JsonDocument d = JsonDocument.Parse(json);
        JsonElement r = d.RootElement;

        bool ok =
            r.TryGetProperty("name", out var n) && n.ValueKind == JsonValueKind.String &&
            r.TryGetProperty("age", out var ag) && ag.ValueKind == JsonValueKind.Number;

        Console.WriteLine(ok);

        List<Student> list = new List<Student>
        {
            new Student { Name = "A", Age = 20 },
            new Student { Name = "B", Age = 30 }
        };
        Console.WriteLine(JsonSerializer.Serialize(list));

        string arrJson = @"[
            { ""name"": ""A"", ""age"": 20 },
            { ""name"": ""B"", ""age"": 30 }
        ]";

        JsonDocument jd = JsonDocument.Parse(arrJson);
        foreach (JsonElement e in jd.RootElement.EnumerateArray())
        {
            if (e.GetProperty("age").GetInt32() > 25)
                Console.WriteLine(e.GetProperty("name").GetString());
        }
    }
}

class Car
{
    public string Brand { get; set; }
    public int Year { get; set; }
}

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}
