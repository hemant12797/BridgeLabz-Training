
using System;
using System.IO;

class Program {
    static void Main() {
        Console.WriteLine("Enter text to write to file:");
        using (StreamReader sr = new StreamReader(Console.OpenStandardInput())) {
            string input = sr.ReadLine();
            string filePath = "output.txt";
            using (StreamWriter sw = new StreamWriter(filePath)) {
                sw.WriteLine(input);
            }
            Console.WriteLine("Text written to file.");
        }
    }
}
