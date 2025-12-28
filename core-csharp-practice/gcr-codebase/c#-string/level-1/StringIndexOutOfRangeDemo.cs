
using System;

class StringIndexOutOfRangeDemo
{
    static void Main()
    {
        try
        {
            string s = "Hello";
            Console.WriteLine(s[10]);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.GetType().Name);
        }
    }
}
