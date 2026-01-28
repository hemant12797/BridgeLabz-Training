using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class ImportantMethodAttribute : Attribute
{
    public string Level { get; set; } = "HIGH";
}

class Service
{
    [ImportantMethod]
    public void Start() { }

    [ImportantMethod(Level = "LOW")]
    public void Stop() { }
}

class ImportantMethodAttributeDemo
{
    static void Main()
    {
        foreach (var m in typeof(Service).GetMethods())
        {
            var attr = (ImportantMethodAttribute)Attribute.GetCustomAttribute(m, typeof(ImportantMethodAttribute));
            if (attr != null)
                Console.WriteLine($"{m.Name} - Level: {attr.Level}");
        }
    }
}