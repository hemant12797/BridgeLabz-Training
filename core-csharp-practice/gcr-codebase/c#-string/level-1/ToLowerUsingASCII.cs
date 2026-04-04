
using System;

class ToLowerUsingASCII
{
    static string Convert(string s)
    {
        string r = "";
        foreach (char c in s)
        {
            if (c >= 'A' && c <= 'Z')
                r += (char)(c + 32);
            else
                r += c;
        }
        return r;
    }

    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(Convert(s));
        Console.WriteLine(s.ToLower());
    }
}
