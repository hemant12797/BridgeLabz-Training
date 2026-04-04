using System;
using System.Text;

class Program {
    static void Main() {
        string input = "hello";
        StringBuilder sb = new StringBuilder(input);
        sb.Reverse();
        Console.WriteLine(sb.ToString());
    }
}
