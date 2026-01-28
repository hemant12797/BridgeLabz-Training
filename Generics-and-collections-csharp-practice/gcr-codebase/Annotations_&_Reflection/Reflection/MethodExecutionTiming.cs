using System;
using System.Diagnostics;
using System.Reflection;

class TaskRunner
{
    public void Run()
    {
        System.Threading.Thread.Sleep(500);
    }
}

class MethodExecutionTiming
{
    static void Main()
    {
        TaskRunner t = new TaskRunner();
        MethodInfo method = typeof(TaskRunner).GetMethod("Run");

        Stopwatch sw = Stopwatch.StartNew();
        method.Invoke(t, null);
        sw.Stop();

        Console.WriteLine("Execution Time: " + sw.ElapsedMilliseconds + " ms");
    }
}