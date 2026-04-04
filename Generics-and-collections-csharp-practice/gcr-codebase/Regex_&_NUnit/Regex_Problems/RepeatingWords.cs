using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  string t="This is is a test test";
  foreach(Match m in Regex.Matches(t, @"\b(\w+)\s+\1\b"))
   Console.WriteLine(m.Groups[1].Value);
 }
}