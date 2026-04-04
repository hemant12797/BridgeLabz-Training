using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  Console.WriteLine(Regex.IsMatch("4111111111111111", @"^4\d{15}$"));
  Console.WriteLine(Regex.IsMatch("5111111111111111", @"^5\d{15}$"));
 }
}