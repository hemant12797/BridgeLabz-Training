using System;
using System.IO;

class Program {
    static void Main() {
        string filePath = "example.txt"; // Assume file exists
        string wordToCount = "the";
        int count = 0;
        using (StreamReader sr = new StreamReader(filePath)) {
            string line;
            while ((line = sr.ReadLine()) != null) {
                string[] words = line.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words) {
                    if (word.Equals(wordToCount, StringComparison.OrdinalIgnoreCase)) {
                        count++;
                    }
                }
            }
        }
        Console.WriteLine($"The word '{wordToCount}' appears {count} times.");
    }
}
