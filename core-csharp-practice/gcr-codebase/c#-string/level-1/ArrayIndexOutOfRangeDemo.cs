
using System;

class ArrayIndexOutOfRangeDemo
{
    static void Main()
    {
        try
        {
            int[] a = {1,2,3};
            Console.WriteLine(a[5]);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.GetType().Name);
        }
    }
}
