using System;
using System.Text;
using System.Collections.Generic;

class Program {
    static void Main() {
        string input = "hello world";
        StringBuilder sb = new StringBuilder();
        HashSet<char> seen = new HashSet<char>();
        foreach (char c in input) {
            if (!seen.Contains(c)) {
                seen.Add(c);
                sb.Append(c);
            }
        }
        Console.WriteLine(sb.ToString());
    }
}
