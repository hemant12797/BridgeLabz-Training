using System;
using System.Reflection;

interface IGreeting
{
    void SayHello();
}

class Greeting : IGreeting
{
    public void SayHello()
    {
        Console.WriteLine("Hello User");
    }
}

class LoggingProxy : DispatchProxy
{
    public IGreeting Target;

    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        Console.WriteLine("Calling Method: " + targetMethod.Name);
        return targetMethod.Invoke(Target, args);
    }
}

class LoggingProxyDemo
{
    static void Main()
    {
        IGreeting greeting = DispatchProxy.Create<IGreeting, LoggingProxy>();
        ((LoggingProxy)greeting).Target = new Greeting();

        greeting.SayHello();
    }
}