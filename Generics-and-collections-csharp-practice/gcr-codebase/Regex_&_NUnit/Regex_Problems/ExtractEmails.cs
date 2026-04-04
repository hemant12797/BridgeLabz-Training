using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  string t="Contact us at support@example.com and info@company.org";
  foreach(Match m in Regex.Matches(t, @"\b[\w.-]+@[\w.-]+\.\w+\b"))
   Console.WriteLine(m.Value);
 }
}