using System;

class DateArithmeticDemo
{
    static void Main()
    {
        Console.Write("Enter a date (yyyy-MM-dd): ");
        DateTime inputDate = DateTime.Parse(Console.ReadLine());

        DateTime result = inputDate.AddDays(7)
                                    .AddMonths(1)
                                    .AddYears(2)
                                    .AddDays(-21);

        Console.WriteLine("Final Date: " + result.ToShortDateString());
    }
}