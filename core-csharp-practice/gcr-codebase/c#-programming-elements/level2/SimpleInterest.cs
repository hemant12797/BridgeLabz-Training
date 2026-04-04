using System;

public class SimpleInterest
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the Principal amount: ");
        int Principal = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the rate: ");
        float rate = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter the time: ");
        int time = int.Parse(Console.ReadLine());

        // Simple Interest = (Principal * Rate * Time) / 100

        float simpleInterest = (Principal * rate * time) / 100;

        Console.WriteLine("The Simple Interest is "+ simpleInterest +" for Principal "+ Principal +", Rate of Interest "+ rate +" and Time "+time);
    }
}