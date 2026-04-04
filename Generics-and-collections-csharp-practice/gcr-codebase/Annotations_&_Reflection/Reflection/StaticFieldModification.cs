using System;
using System.Reflection;

class Configuration
{
    private static string API_KEY = "OLD_KEY";
}

class StaticFieldModification
{
    static void Main()
    {
        Type t = typeof(Configuration);
        FieldInfo field = t.GetField("API_KEY", BindingFlags.NonPublic | BindingFlags.Static);

        field.SetValue(null, "NEW_KEY");
        Console.WriteLine("Updated API_KEY: " + field.GetValue(null));
    }
}