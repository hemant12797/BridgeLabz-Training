using System;
public class celsiusToFahrenheit{
    static void Main(string[] args){
        double celcius = double.Parse(Console.ReadLine());
        double Fahrenheit = (celcius*9)/5+32;
        Console.WriteLine("celsiusToFahrenheit --> "+Fahrenheit);
    }
}