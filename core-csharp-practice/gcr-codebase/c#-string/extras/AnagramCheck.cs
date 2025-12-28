
using System;

class AnagramCheck
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();

        if (a.Length != b.Length)
        {
            Console.WriteLine("Not Anagram");
            return;
        }

        int[] freq = new int[256];

        foreach (char c in a) freq[c]++;
        foreach (char c in b) freq[c]--;

        foreach (int x in freq)
            if (x != 0)
            {
                Console.WriteLine("Not Anagram");
                return;
            }

        Console.WriteLine("Anagram");
    }
}
