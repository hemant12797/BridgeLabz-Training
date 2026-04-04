using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  string t="The Eiffel Tower is in Paris";
  foreach(Match m in Regex.Matches(t, @"\b[A-Z][a-z]*\b"))
   Console.WriteLine(m.Value);
 }
}