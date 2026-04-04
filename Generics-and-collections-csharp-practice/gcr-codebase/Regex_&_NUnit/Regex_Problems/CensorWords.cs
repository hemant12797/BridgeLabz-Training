using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  string t="This is a damn stupid test";
  Console.WriteLine(Regex.Replace(t, @"\b(damn|stupid)\b", "****", RegexOptions.IgnoreCase));
 }
}