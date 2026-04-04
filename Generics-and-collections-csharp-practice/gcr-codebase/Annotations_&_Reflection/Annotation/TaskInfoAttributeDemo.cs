using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class TaskInfoAttribute : Attribute
{
    public string Priority { get; set; }
    public string AssignedTo { get; set; }
}

class TaskManager
{
    [TaskInfo(Priority = "HIGH", AssignedTo = "Ashish")]
    public void CompleteTask() { }
}

class TaskInfoAttributeDemo
{
    static void Main()
    {
        MethodInfo method = typeof(TaskManager).GetMethod("CompleteTask");
        var attr = (TaskInfoAttribute)Attribute.GetCustomAttribute(method, typeof(TaskInfoAttribute));

        Console.WriteLine($"Priority: {attr.Priority}, AssignedTo: {attr.AssignedTo}");
    }
}