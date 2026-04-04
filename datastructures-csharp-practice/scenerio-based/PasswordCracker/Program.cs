using System;
using System.Diagnostics;

class Program
{
    static string targetPassword = "abc"; // Example target password
    static string charset = "abcdefghijklmnopqrstuvwxyz"; // Lowercase letters
    static bool found = false;
    static int attempts = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Password Cracker Simulator using Backtracking");
        Console.WriteLine($"Target Password: {targetPassword}");
        Console.WriteLine($"Charset: {charset}");
        Console.WriteLine($"Password Length: {targetPassword.Length}");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Scenario A: Generate all strings of length n using backtracking
        Backtrack("", targetPassword.Length);

        stopwatch.Stop();

        if (found)
        {
            Console.WriteLine($"Password found after {attempts} attempts.");
        }
        else
        {
            Console.WriteLine("Password not found.");
        }

        // Scenario C: Visualize time-space complexity
        Console.WriteLine($"\nTime taken: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Space complexity: O(n) for recursion stack, where n is password length.");
        Console.WriteLine($"Time complexity: O(k^n), where k is charset size ({charset.Length}), n is length ({targetPassword.Length}).");
        Console.WriteLine($"Total possible combinations: {Math.Pow(charset.Length, targetPassword.Length)}");
    }

    // Backtracking function to generate combinations
    static void Backtrack(string current, int maxLength)
    {
        if (found) return; // Scenario B: Stop if password is matched

        if (current.Length == maxLength)
        {
            attempts++;
            if (current == targetPassword)
            {
                found = true;
                Console.WriteLine($"Found password: {current}");
            }
            return;
        }

        foreach (char c in charset)
        {
            Backtrack(current + c, maxLength);
        }
    }
}
