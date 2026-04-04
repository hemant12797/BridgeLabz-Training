
using System;

class MostFrequentCharacter
{
    static void Main()
    {
        string s = Console.ReadLine();
        int max = 0;
        char result = ' ';

        for (int i = 0; i < s.Length; i++)
        {
            int count = 1;
            for (int j = i + 1; j < s.Length; j++)
                if (s[i] == s[j]) count++;

            if (count > max)
            {
                max = count;
                result = s[i];
            }
        }

        Console.WriteLine(result);
    }
}
