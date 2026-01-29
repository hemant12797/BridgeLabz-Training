
using System;
using System.IO;
using System.Text.RegularExpressions;

class ValidateCSV
{
    static void Main()
    {
        Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        Regex phoneRegex = new Regex(@"^\d{10}$");

        var lines = File.ReadAllLines("users.csv");

        for (int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split(',');

            if (!emailRegex.IsMatch(data[2]) ||
                !phoneRegex.IsMatch(data[3]))
            {
                Console.WriteLine("Invalid Row: " + lines[i]);
            }
        }
    }
}
