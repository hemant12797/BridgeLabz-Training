
using System;

class CompareStringsUsingIndex
{
    static bool Compare(string a, string b)
    {
        if (a == null || b == null) return false;
        if (a.Length != b.Length) return false;

        for (int i = 0; i < a.Length; i++)
            if (a[i] != b[i]) return false;

        return true;
    }

    static void Main()
    {
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();

        Console.WriteLine(Compare(s1, s2));
        Console.WriteLine(s1.Equals(s2));
    }
}
