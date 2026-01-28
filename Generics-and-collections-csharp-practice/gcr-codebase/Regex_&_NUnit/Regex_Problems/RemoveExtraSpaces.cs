using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  string t="This   is   spaced";
  Console.WriteLine(Regex.Replace(t, @"\s+", " "));
 }
}