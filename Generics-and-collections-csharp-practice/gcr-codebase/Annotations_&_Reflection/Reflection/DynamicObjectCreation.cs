using System;
using System.Reflection;

class Student
{
    public string Name = "Rahul";
}

class DynamicObjectCreation
{
    static void Main()
    {
        Type t = typeof(Student);
        object obj = Activator.CreateInstance(t);

        Console.WriteLine(((Student)obj).Name);
    }
}