using System;
using System.Text.RegularExpressions;
class Program {
 static void Main() {
  string ip="192.168.1.1";
  Console.WriteLine(Regex.IsMatch(ip,
   @"^((25[0-5]|2[0-4]\d|1?\d?\d)\.){3}(25[0-5]|2[0-4]\d|1?\d?\d)$"));
 }
}