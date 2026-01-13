using System;
using System.Text;
using System.Diagnostics;

class Program {
    static void Main() {
        int iterations = 10000;
        string baseString = "test";

        // Using StringBuilder
        Stopwatch sw = Stopwatch.StartNew();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++) {
            sb.Append(baseString);
        }
        sw.Stop();
        Console.WriteLine($"StringBuilder time: {sw.ElapsedMilliseconds} ms");

        // Using string concatenation
        sw.Restart();
        string result = "";
        for (int i = 0; i < iterations; i++) {
            result += baseString;
        }
        sw.Stop();
        Console.WriteLine($"String concatenation time: {sw.ElapsedMilliseconds} ms");
    }
}
