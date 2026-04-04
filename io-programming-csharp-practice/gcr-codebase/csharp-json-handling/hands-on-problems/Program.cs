using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Collections.Generic;
using System.Xml;

class Program
{
    static void Main()
    {
        File.WriteAllText("data.json",
        @"{ ""name"": ""A"", ""age"": 30, ""email"": ""a@mail.com"" }");

        JsonDocument doc = JsonDocument.Parse(File.ReadAllText("data.json"));
        foreach (JsonProperty p in doc.RootElement.EnumerateObject())
            Console.WriteLine(p.Name + " : " + p.Value);

        List<User> users = new List<User>
        {
            new User { Name = "X", Age = 20, Email = "x@mail.com" },
            new User { Name = "Y", Age = 30, Email = "y@mail.com" }
        };

        string usersJson = JsonSerializer.Serialize(users);
        Console.WriteLine(usersJson);

        JsonDocument jd = JsonDocument.Parse(usersJson);
        foreach (JsonElement e in jd.RootElement.EnumerateArray())
            if (e.GetProperty("Age").GetInt32() > 25)
                Console.WriteLine(e.GetProperty("Name").GetString());

        string email = jd.RootElement[0].GetProperty("Email").GetString();
        bool ok = email.Contains("@") && email.Contains(".");
        Console.WriteLine(ok);

        File.WriteAllText("a.json", @"{ ""name"": ""John"" }");
        File.WriteAllText("b.json", @"{ ""email"": ""john@mail.com"" }");

        JsonObject o1 = JsonNode.Parse(File.ReadAllText("a.json")).AsObject();
        JsonObject o2 = JsonNode.Parse(File.ReadAllText("b.json")).AsObject();

        foreach (var x in o2)
            o1[x.Key] = x.Value.DeepClone();

        Console.WriteLine(o1.ToJsonString());

        XmlDocument xml = new XmlDocument();
        XmlElement root = xml.CreateElement("root");
        xml.AppendChild(root);

        foreach (var x in o1)
        {
            XmlElement el = xml.CreateElement(x.Key);
            el.InnerText = x.Value.ToString();
            root.AppendChild(el);
        }

        Console.WriteLine(xml.OuterXml);

        string csv = "name,age\nA,20\nB,30";
        string[] lines = csv.Split('\n');

        JsonArray arr = new JsonArray();
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            JsonObject obj = new JsonObject
            {
                ["name"] = parts[0],
                ["age"] = int.Parse(parts[1])
            };
            arr.Add(obj);
        }

        Console.WriteLine(arr.ToJsonString());

        List<User> db = new List<User>
        {
            new User { Name = "DB1", Age = 40, Email = "db1@mail.com" },
            new User { Name = "DB2", Age = 35, Email = "db2@mail.com" }
        };

        Console.WriteLine(JsonSerializer.Serialize(db));
    }
}

class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}
