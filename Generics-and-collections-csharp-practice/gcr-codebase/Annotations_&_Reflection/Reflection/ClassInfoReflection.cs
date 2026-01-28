using System;
using System.Reflection;

class Sample
{
    public int x;
    private int y;

    public Sample() { }
    public void Show() { }
}

class ClassInfoReflection
{
    static void Main()
    {
        Console.Write("Enter class name: ");
        string className = Console.ReadLine();

        Type type = Type.GetType(className);

        if (type == null)
        {
            Console.WriteLine("Class not found");
            return;
        }

        Console.WriteLine("Methods:");
        foreach (var m in type.GetMethods())
            Console.WriteLine(m.Name);

        Console.WriteLine("Fields:");
        foreach (var f in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            Console.WriteLine(f.Name);

        Console.WriteLine("Constructors:");
        foreach (var c in type.GetConstructors())
            Console.WriteLine(c.Name);
    }
}