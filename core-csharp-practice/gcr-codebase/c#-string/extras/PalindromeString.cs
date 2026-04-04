
using System;

class PalindromeString
{
    static void Main()
    {
        string s = Console.ReadLine();
        int i = 0, j = s.Length - 1;
        bool ok = true;

        while (i < j)
        {
            if (s[i] != s[j]) { ok = false; break; }
            i++; j--;
        }

        Console.WriteLine(ok ? "Palindrome" : "Not Palindrome");
    }
}
