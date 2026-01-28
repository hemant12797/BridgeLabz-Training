using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class TodoAttribute : Attribute
{
    public string Task { get; set; }
    public string AssignedTo { get; set; }
    public string Priority { get; set; } = "MEDIUM";
}

class Project
{
    [Todo(Task = "Add validation", AssignedTo = "Dev1")]
    public void FeatureA() { }

    [Todo(Task = "Improve UI", AssignedTo = "Dev2", Priority = "HIGH")]
    public void FeatureB() { }
}

class TodoAttributeDemo
{
    static void Main()
    {
        foreach (var m in typeof(Project).GetMethods())
        {
            var attr = (TodoAttribute)Attribute.GetCustomAttribute(m, typeof(TodoAttribute));
            if (attr != null)
                Console.WriteLine($"{m.Name}: {attr.Task}, {attr.AssignedTo}, {attr.Priority}");
        }
    }
}