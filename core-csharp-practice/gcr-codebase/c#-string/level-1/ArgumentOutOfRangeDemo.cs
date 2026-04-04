
using System;

class ArgumentOutOfRangeDemo
{
    static void Main()
    {
        try
        {
            string s = "Hello";
            Console.WriteLine(s.Substring(4, 10));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.GetType().Name);
        }
    }
}
