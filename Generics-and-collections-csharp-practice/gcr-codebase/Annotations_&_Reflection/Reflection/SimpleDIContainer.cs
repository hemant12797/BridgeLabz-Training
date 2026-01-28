using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Field)]
class InjectAttribute : Attribute { }

class Service
{
    public void Run() => Console.WriteLine("Service Running");
}

class Client
{
    [Inject]
    public Service service;
}

class SimpleDIContainer
{
    static void Main()
    {
        Client c = new Client();
        var fields = typeof(Client).GetFields();

        foreach (var f in fields)
        {
            if (Attribute.IsDefined(f, typeof(InjectAttribute)))
            {
                object obj = Activator.CreateInstance(f.FieldType);
                f.SetValue(c, obj);
            }
        }

        c.service.Run();
    }
}