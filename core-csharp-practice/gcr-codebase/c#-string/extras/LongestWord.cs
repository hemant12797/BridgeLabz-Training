
using System;

class LongestWord
{
    static void Main()
    {
        string s = Console.ReadLine();
        string word = "", longest = "";

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')
                word += s[i];
            else
            {
                if (word.Length > longest.Length) longest = word;
                word = "";
            }
        }

        if (word.Length > longest.Length) longest = word;
        Console.WriteLine(longest);
    }
}
