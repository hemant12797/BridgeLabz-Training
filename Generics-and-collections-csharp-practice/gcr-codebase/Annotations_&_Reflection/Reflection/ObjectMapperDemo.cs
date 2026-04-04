using System;
using System.Collections.Generic;
using System.Reflection;

class ObjectMapper
{
    public static T ToObject<T>(Dictionary<string, object> data) where T : new()
    {
        T obj = new T();
        Type t = typeof(T);

        foreach (var item in data)
        {
            PropertyInfo prop = t.GetProperty(item.Key);
            if (prop != null)
                prop.SetValue(obj, item.Value);
        }
        return obj;
    }
}

class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class ObjectMapperDemo
{
    static void Main()
    {
        var dict = new Dictionary<string, object> {
            {"Name","Amit"},
            {"Age",25}
        };

        User u = ObjectMapper.ToObject<User>(dict);
        Console.WriteLine(u.Name + " " + u.Age);
    }
}