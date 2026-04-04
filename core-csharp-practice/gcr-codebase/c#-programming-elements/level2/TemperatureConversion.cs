using System;

public class TemperatureConversion
{
    public static void Main(String[] args)
    {
        Console.Write("Enter the temperture in Celcius : ");
        float tempInCelcius = float.Parse(Console.ReadLine());

        float tempInFahrenheit = (tempInCelcius * 9/5f) + 32;

        Console.WriteLine("The "+ tempInCelcius  +" Celsius is "+ tempInFahrenheit  +" Fahrenheit");
    }
}