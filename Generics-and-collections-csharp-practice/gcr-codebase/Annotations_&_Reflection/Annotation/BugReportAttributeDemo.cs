using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class BugReportAttribute : Attribute
{
    public string Description { get; set; }
    public BugReportAttribute(string desc)
    {
        Description = desc;
    }
}

class BugTracker
{
    [BugReport("Null reference issue")]
    [BugReport("Performance slowdown")]
    public void Process() { }
}

class BugReportAttributeDemo
{
    static void Main()
    {
        MethodInfo method = typeof(BugTracker).GetMethod("Process");
        var bugs = method.GetCustomAttributes(typeof(BugReportAttribute), false);

        foreach (BugReportAttribute bug in bugs)
            Console.WriteLine("Bug: " + bug.Description);
    }
}