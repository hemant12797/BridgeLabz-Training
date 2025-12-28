using System;

class PalindromeChecker
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        if (IsPalindrome(input))
            Console.WriteLine("Palindrome");
        else
            Console.WriteLine("Not a palindrome");
    }

    static bool IsPalindrome(string text)
    {
        string rev = "";
        for (int i = text.Length - 1; i >= 0; i--)
            rev += text[i];

        return text.Equals(rev, StringComparison.OrdinalIgnoreCase);
    }
}