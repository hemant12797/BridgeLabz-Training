using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  string t="Price $45.99 and $ 10.50";
  foreach(Match m in Regex.Matches(t, @"\$?\s?\d+\.\d{2}"))
   Console.WriteLine(m.Value.Trim());
 }
}