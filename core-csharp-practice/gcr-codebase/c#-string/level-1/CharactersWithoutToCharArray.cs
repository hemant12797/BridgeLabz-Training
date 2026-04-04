
using System;

class CharactersWithoutToCharArray
{
    static char[] GetChars(string s)
    {
        char[] arr = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
            arr[i] = s[i];
        return arr;
    }

    static void Main()
    {
        string s = Console.ReadLine();

        char[] a = GetChars(s);
        foreach (char c in a)
            Console.Write(c + " ");
        Console.WriteLine();

        char[] b = s.ToCharArray();
        foreach (char c in b)
            Console.Write(c + " ");
    }
}
