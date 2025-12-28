using System;

class TemperatureConverter
{
    static void Main()
    {
        Console.Write("Enter temperature: ");
        double temp = double.Parse(Console.ReadLine());

        Console.Write("Convert to (C/F): ");
        char choice = char.ToUpper(Console.ReadLine()[0]);

        if (choice == 'C')
            Console.WriteLine("Celsius: " + FahrenheitToCelsius(temp));
        else
            Console.WriteLine("Fahrenheit: " + CelsiusToFahrenheit(temp));
    }

    static double FahrenheitToCelsius(double f)
    {
        return (f - 32) * 5 / 9;
    }

    static double CelsiusToFahrenheit(double c)
    {
        return (c * 9 / 5) + 32;
    }
}