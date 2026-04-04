using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  string t="Visit https://www.google.com and http://example.org";
  foreach(Match m in Regex.Matches(t, @"https?://\S+"))
   Console.WriteLine(m.Value);
 }
}