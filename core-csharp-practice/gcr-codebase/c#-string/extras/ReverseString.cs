
using System;

class ReverseString
{
    static void Main()
    {
        string s = Console.ReadLine();
        string r = "";

        for (int i = s.Length - 1; i >= 0; i--)
            r += s[i];

        Console.WriteLine(r);
    }
}
