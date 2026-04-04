using System;
using System.IO;
using System.Text;

class Program {
    static void Main() {
        string filePath = "binaryfile.bin"; // Assume binary file exists
        using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8)) {
            string content = sr.ReadToEnd();
            Console.WriteLine(content);
        }
    }
}
