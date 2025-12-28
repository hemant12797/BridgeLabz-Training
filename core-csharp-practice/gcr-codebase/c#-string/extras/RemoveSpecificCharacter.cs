
using System;

class RemoveSpecificCharacter
{
    static void Main()
    {
        string s = Console.ReadLine();
        char rem = Console.ReadLine()[0];
        string r = "";

        foreach (char c in s)
            if (c != rem) r += c;

        Console.WriteLine(r);
    }
}
