using System;
using System.Reflection;

class Person
{
    private int age = 20;
}

class AccessPrivateField
{
    static void Main()
    {
        Person p = new Person();
        Type t = typeof(Person);

        FieldInfo field = t.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(p, 30);

        Console.WriteLine("Age: " + field.GetValue(p));
    }
}