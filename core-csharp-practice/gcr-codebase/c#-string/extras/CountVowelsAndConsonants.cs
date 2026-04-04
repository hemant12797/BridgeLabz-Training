
using System;

class CountVowelsAndConsonants
{
    static void Main()
    {
        string s = Console.ReadLine().ToLower();
        int v = 0, c = 0;

        foreach (char ch in s)
        {
            if (ch >= 'a' && ch <= 'z')
            {
                if ("aeiou".IndexOf(ch) != -1) v++;
                else c++;
            }
        }

        Console.WriteLine("Vowels: " + v);
        Console.WriteLine("Consonants: " + c);
    }
}
