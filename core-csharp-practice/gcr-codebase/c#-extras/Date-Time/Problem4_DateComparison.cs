using System;

class DateComparisonDemo
{
    static void Main()
    {
        Console.Write("Enter first date (yyyy-MM-dd): ");
        DateTime date1 = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter second date (yyyy-MM-dd): ");
        DateTime date2 = DateTime.Parse(Console.ReadLine());

        int result = DateTime.Compare(date1, date2);

        if (result < 0)
            Console.WriteLine("First date is earlier than second date.");
        else if (result > 0)
            Console.WriteLine("First date is later than second date.");
        else
            Console.WriteLine("Both dates are the same.");
    }
}