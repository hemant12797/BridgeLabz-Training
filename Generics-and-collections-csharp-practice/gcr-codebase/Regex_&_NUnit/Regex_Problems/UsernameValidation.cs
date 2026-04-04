using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  string u="user_123";
  Console.WriteLine(Regex.IsMatch(u, @"^[A-Za-z]\w{4,14}$"));
 }
}