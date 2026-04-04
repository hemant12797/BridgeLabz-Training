
using System;

class ReplaceCharacter
{
    static void Main()
    {
        string s = Console.ReadLine();
        char oldc = Console.ReadLine()[0];
        char newc = Console.ReadLine()[0];
        string r = "";

        foreach (char c in s)
            r += (c == oldc) ? newc : c;

        Console.WriteLine(r);
    }
}
