using System;
using System.IO;

class Program {
    static void Main() {
        string filePath = "example.txt"; // Assume file exists
        using (StreamReader sr = new StreamReader(filePath)) {
            string line;
            while ((line = sr.ReadLine()) != null) {
                Console.WriteLine(line);
            }
        }
    }
}
