using System;
public class SpringSeason
{
    public static void Main(String[] args)
    {
        Console.Write("Enter month (as a number): ");
        int month = int.Parse(Console.ReadLine());

        Console.Write("Enter day: ");
        int day = int.Parse(Console.ReadLine());

        // Spring is from March 20 to June 20
        bool isSpring = (month == 3 && day >= 20) || (month == 4) || (month == 5) || (month == 6 && day <= 20);

        if(isSpring)
        {
            Console.WriteLine("It's a Spring Season");
        }
        else
        {
            Console.WriteLine("Not a Spring Season");
        }
    }
}