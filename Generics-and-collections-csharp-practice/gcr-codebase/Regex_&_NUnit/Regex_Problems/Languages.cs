using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  string t="I love Java, Python, JavaScript and Go";
  foreach(Match m in Regex.Matches(t, @"JavaScript|Java|Python|Go"))
   Console.WriteLine(m.Value);
 }
}