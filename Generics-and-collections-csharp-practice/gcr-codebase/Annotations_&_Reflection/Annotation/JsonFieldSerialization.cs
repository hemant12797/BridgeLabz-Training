using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Field)]
class JsonFieldAttribute : Attribute
{
    public string Name { get; set; }
}

class User
{
    [JsonField(Name = "user_name")]
    public string Name;

    [JsonField(Name = "user_age")]
    public int Age;
}

class JsonFieldSerialization
{
    static void Main()
    {
        User u = new User { Name = "Amit", Age = 25 };
        Type t = typeof(User);

        string json = "{";
        foreach (var f in t.GetFields())
        {
            var attr = (JsonFieldAttribute)Attribute.GetCustomAttribute(f, typeof(JsonFieldAttribute));
            if (attr != null)
                json += $"\"{attr.Name}\":\"{f.GetValue(u)}\",";
        }

        Console.WriteLine(json.TrimEnd(',') + "}");
    }
}