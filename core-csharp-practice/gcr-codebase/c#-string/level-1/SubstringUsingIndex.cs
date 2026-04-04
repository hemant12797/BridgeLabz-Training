
using System;

class SubstringUsingIndex
{
    static string CreateSub(string s, int start, int end)
    {
        string r = "";
        for (int i = start; i <= end; i++)
            r += s[i];
        return r;
    }

    static void Main()
    {
        string s = Console.ReadLine();
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        Console.WriteLine(CreateSub(s, start, end));
        Console.WriteLine(s.Substring(start, end - start + 1));
    }
}
