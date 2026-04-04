using System;

class LeapYear
{
    static bool IsLeap(int y)
    {
        if (y < 1582) return false;
        if (y % 400 == 0) return true;
        if (y % 100 == 0) return false;
        return y % 4 == 0;
    }

    static void Main()
    {
        int y = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(IsLeap(y));
    }
}