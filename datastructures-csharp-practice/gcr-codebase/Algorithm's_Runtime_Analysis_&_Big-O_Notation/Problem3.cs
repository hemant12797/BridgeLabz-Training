using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] counts = { 1000, 10000, 1000000 };

        foreach (int count in counts)
        {
            // String concatenation
            Stopwatch sw = Stopwatch.StartNew();
            string result1 = "";
            for (int i = 0; i < count; i++)
            {
                result1 += "a";
            }
            sw.Stop();
            Console.WriteLine($"String concatenation for {count}: {sw.ElapsedMilliseconds} ms");

            // StringBuilder
            sw.Restart();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append("a");
            }
            string result2 = sb.ToString();
            sw.Stop();
            Console.WriteLine($"StringBuilder for {count}: {sw.ElapsedMilliseconds} ms");
        }
    }
}
