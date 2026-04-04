
using System;

class NullReferenceExceptionDemo
{
    static void Main()
    {
        try
        {
            string s = null;
            Console.WriteLine(s.Length);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.GetType().Name);
        }
    }
}
