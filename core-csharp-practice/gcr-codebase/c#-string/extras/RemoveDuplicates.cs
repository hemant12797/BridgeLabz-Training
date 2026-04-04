
using System;

class RemoveDuplicates
{
    static void Main()
    {
        string s = Console.ReadLine();
        string res = "";

        foreach (char c in s)
            if (res.IndexOf(c) == -1)
                res += c;

        Console.WriteLine(res);
    }
}
