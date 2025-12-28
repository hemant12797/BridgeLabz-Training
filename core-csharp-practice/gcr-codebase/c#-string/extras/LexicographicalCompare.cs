
using System;

class LexicographicalCompare
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();

        int len = a.Length < b.Length ? a.Length : b.Length;
        bool decided = false;

        for (int i = 0; i < len; i++)
        {
            if (a[i] < b[i])
            {
                Console.WriteLine(a + " comes before " + b);
                decided = true;
                break;
            }
            else if (a[i] > b[i])
            {
                Console.WriteLine(b + " comes before " + a);
                decided = true;
                break;
            }
        }

        if (!decided)
        {
            if (a.Length == b.Length) Console.WriteLine("Both are equal");
            else if (a.Length < b.Length) Console.WriteLine(a + " comes before " + b);
            else Console.WriteLine(b + " comes before " + a);
        }
    }
}
