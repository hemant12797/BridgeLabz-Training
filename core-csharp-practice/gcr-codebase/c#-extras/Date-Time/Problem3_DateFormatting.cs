using System;

class DateFormattingDemo
{
    static void Main()
    {
        DateTime today = DateTime.Now;

        Console.WriteLine(today.ToString("dd/MM/yyyy"));
        Console.WriteLine(today.ToString("yyyy-MM-dd"));
        Console.WriteLine(today.ToString("ddd, MMM dd, yyyy"));
    }
}