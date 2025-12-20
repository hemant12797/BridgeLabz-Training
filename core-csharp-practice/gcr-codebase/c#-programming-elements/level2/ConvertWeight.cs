using System;

public class ConvertWeight
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter the weight in pounds :");
        float weightInPounds = float.Parse(Console.ReadLine());

        //1 pound = 2.2 kg

        float weightInKgs = weightInPounds * 2.2f;

        Console.WriteLine("The weight of the person in pounds is "+ weightInPounds +" and in kg is "+weightInKgs);
    }
}