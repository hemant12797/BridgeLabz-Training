using System;

public class TotalIncome
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter your salary :");
        int salary = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter your bonus :");
        int bonus = int.Parse(Console.ReadLine());

        int income = salary + bonus;

        Console.WriteLine("The salary is INR "+ salary +" and bonus is INR "+ bonus +" Hence Total Income is INR "+income);
        
    }
}