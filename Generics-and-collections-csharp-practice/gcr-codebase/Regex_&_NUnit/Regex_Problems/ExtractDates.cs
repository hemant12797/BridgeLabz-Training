using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  string t="Dates: 12/05/2023, 15/08/2024";
  foreach(Match m in Regex.Matches(t, @"\b\d{2}/\d{2}/\d{4}\b"))
   Console.WriteLine(m.Value);
 }
}