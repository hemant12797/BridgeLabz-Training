
using System;

class ToUpperUsingASCII
{
    static string Convert(string s)
    {
        string r = "";
        foreach (char c in s)
        {
            if (c >= 'a' && c <= 'z')
                r += (char)(c - 32);
            else
                r += c;
        }
        return r;
    }

    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(Convert(s));
        Console.WriteLine(s.ToUpper());
    }
}
