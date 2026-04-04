using System;
using System.Reflection;

class JsonGeneratorReflection
{
    public static string ToJson(object obj)
    {
        Type t = obj.GetType();
        var fields = t.GetFields(BindingFlags.Public | BindingFlags.Instance);

        string json = "{";
        foreach (var f in fields)
            json += $"\"{f.Name}\":\"{f.GetValue(obj)}\",";

        return json.TrimEnd(',') + "}";
    }

    static void Main()
    {
        var p = new { Name = "Ravi", Age = 22 };
        Console.WriteLine(ToJson(p));
    }
}