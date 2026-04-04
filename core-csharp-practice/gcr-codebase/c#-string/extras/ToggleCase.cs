
using System;

class ToggleCase
{
    static void Main()
    {
        string s = Console.ReadLine();
        string r = "";

        foreach (char c in s)
        {
            if (c >= 'a' && c <= 'z') r += (char)(c - 32);
            else if (c >= 'A' && c <= 'Z') r += (char)(c + 32);
            else r += c;
        }

        Console.WriteLine(r);
    }
}
