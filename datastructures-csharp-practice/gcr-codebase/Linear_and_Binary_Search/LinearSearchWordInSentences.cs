using System;

class Program {
    static void Main() {
        string[] sentences = { "Hello world", "This is a test", "Another sentence" };
        string wordToFind = "test";
        int index = -1;
        for (int i = 0; i < sentences.Length; i++) {
            if (sentences[i].IndexOf(wordToFind, StringComparison.OrdinalIgnoreCase) >= 0) {
                index = i;
                break;
            }
        }
        if (index != -1) {
            Console.WriteLine($"First sentence containing '{wordToFind}' is at index {index}: {sentences[index]}");
        } else {
            Console.WriteLine($"No sentence contains '{wordToFind}'.");
        }
    }
}
