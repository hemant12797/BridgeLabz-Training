
using System;

class SplitWordsAndLengths
{
    static int Len(string s)
    {
        int c = 0;
        foreach (char x in s) c++;
        return c;
    }

    static void Main()
    {
        string s = Console.ReadLine().Trim();

        int spaces = 0;
        foreach (char x in s)
            if (x == ' ') spaces++;

        int words = spaces + 1;
        string[,] ans = new string[words, 2];

        int idx = 0;
        string word = "";

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')
                word += s[i];
            else
            {
                ans[idx,0] = word;
                ans[idx,1] = Len(word).ToString();
                idx++;
                word = "";
            }
        }

        if (word != "")
        {
            ans[idx,0] = word;
            ans[idx,1] = Len(word).ToString();
        }

        for (int i = 0; i < words; i++)
            Console.WriteLine(ans[i,0] + " " + ans[i,1]);
    }
}
