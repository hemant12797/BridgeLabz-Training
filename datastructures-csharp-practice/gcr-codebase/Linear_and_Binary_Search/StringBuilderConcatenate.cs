using System;
using System.Text;

class Program {
    static void Main() {
        string[] strings = { "Hello", " ", "World", "!" };
        StringBuilder sb = new StringBuilder();
        foreach (string s in strings) {
            sb.Append(s);
        }
        Console.WriteLine(sb.ToString());
    }
}
