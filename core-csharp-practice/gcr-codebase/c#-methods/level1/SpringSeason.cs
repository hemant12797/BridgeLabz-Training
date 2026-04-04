using System;

class SpringSeason
{
    static bool IsSpring(int m, int d)
    {
        if (m < 3 || m > 6) return false;
        if (m == 3 && d < 20) return false;
        if (m == 6 && d > 20) return false;
        return true;
    }

    static void Main(string[] args)
    {
        int month = Convert.ToInt32(args[0]);
        int day = Convert.ToInt32(args[1]);

        Console.WriteLine(IsSpring(month, day) ? "Its a Spring Season" : "Not a Spring Season");
    }
}