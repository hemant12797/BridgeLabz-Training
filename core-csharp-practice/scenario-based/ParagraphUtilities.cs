using System;

class ParagraphUtilities
{
    static int CountWords(string text)
    {
        int count = 0;
        for (int i = 1; i < text.Length; i++)
            if (text[i] == ' ' && text[i - 1] != ' ')
                count++;
        return count + 1;
    }

    static int GetLongestWordLength(string text)
    {
        int maxLength = 0, currentLength = 0;
        foreach (char ch in text)
        {
            if (ch == ' ')
            {
                maxLength = Math.Max(maxLength, currentLength);
                currentLength = 0;
            }
            else currentLength++;
        }
        return Math.Max(maxLength, currentLength);
    }

    static bool IsValid(string text) =>
        !(string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text));

    static string ReplaceAllWords(string target, string text, string replacement)
    {
        string[] words = text.Split(' ');
        for (int i = 0; i < words.Length; i++)
            if (string.Equals(words[i], target, StringComparison.OrdinalIgnoreCase))
                words[i] = replacement;
        return string.Join(" ", words);
    }

    static void Main()
    {
        Console.WriteLine("Enter a paragraph:");
        string input = Console.ReadLine();

        Console.WriteLine("1. Count Words\n2. Longest Word Length\n3. Replace Word\n4. Check Validity");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Word Count: " + CountWords(input));
                break;
            case 2:
                Console.WriteLine("Longest Word Length: " + GetLongestWordLength(input));
                break;
            case 3:
                Console.Write("Word to replace: ");
                string target = Console.ReadLine();
                Console.Write("Replacement word: ");
                string replacement = Console.ReadLine();
                Console.WriteLine(ReplaceAllWords(target, input, replacement));
                break;
            case 4:
                Console.WriteLine(IsValid(input) ? "Valid String" : "Invalid String");
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}
