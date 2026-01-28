using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class)]
class AuthorAttribute : Attribute
{
    public string Name;
    public AuthorAttribute(string name) { Name = name; }
}

[Author("hem")]
class DemoClass { }

class AuthorAttributeReflection
{
    static void Main()
    {
        Type t = typeof(DemoClass);
        var attr = (AuthorAttribute)Attribute.GetCustomAttribute(t, typeof(AuthorAttribute));
        Console.WriteLine("Author: " + attr.Name);
    }
}