using System;

class CalendarProgram
{
    static int DayOfWeek(int y, int m)
    {
        int d = 1;
        int y0 = y - (14 - m) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        return (d + x + (31 * m0) / 12) % 7;
    }

    static void Main()
    {
        int m = Convert.ToInt32(Console.ReadLine());
        int y = Convert.ToInt32(Console.ReadLine());

        string[] months = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        int[] days = { 0,31,28,31,30,31,30,31,31,30,31,30,31 };

        if (m == 2 && (y % 400 == 0 || (y % 4 == 0 && y % 100 != 0))) days[2] = 29;

        Console.WriteLine(months[m] + " " + y);
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        int start = DayOfWeek(y, m);
        for (int i = 0; i < start; i++) Console.Write("    ");

        for (int d = 1; d <= days[m]; d++)
        {
            Console.Write(d.ToString().PadLeft(3) + " ");
            if ((d + start) % 7 == 0) Console.WriteLine();
        }
    }
}