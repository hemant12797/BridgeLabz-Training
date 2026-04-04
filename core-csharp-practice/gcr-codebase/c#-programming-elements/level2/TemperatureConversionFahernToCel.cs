using System;

public class TemperatureConversionFahernToCel
{
    public static void Main(String[] args)
    {
        Console.Write("Enter the temperture in Fahrenheit : ");
        float tempInFahrenheit = float.Parse(Console.ReadLine());

        float tempInCelcius = (tempInFahrenheit -32 ) * 5/9;

        Console.WriteLine("The "+ tempInFahrenheit  +" Fahrenheit is "+ tempInCelcius  +" Celsius");
    }
}