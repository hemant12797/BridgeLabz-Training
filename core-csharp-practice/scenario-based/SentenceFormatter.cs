using System;

class SentenceFormatter
{
    static void Main()
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine().Trim();
        Console.WriteLine(FormatSentence(input));
    }

    static bool IsPunctuation(char ch) =>
        ch == '.' || ch == ',' || ch == '!' || ch == '?';

    static string FormatSentence(string text)
    {
        string result = char.ToUpper(text[0]).ToString();

        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] == ' ')
            {
                if (i + 1 < text.Length && !IsPunctuation(text[i + 1]))
                    result += ' ';
            }
            else if (IsPunctuation(text[i]))
            {
                result += text[i] + " ";
                if (i + 1 < text.Length)
                    result += char.ToUpper(text[++i]);
            }
            else result += text[i];
        }
        return result;
    }
}
