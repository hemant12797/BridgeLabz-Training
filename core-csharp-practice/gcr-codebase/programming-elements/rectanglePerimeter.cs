using System;
public class rectanglePerimeter{
    static void Main(string[] args){
        double length = double.Parse(Console.ReadLine());
        double breath = double.Parse(Console.ReadLine());
        double perimeter = 2*(length+breath);
        Console.WriteLine("Perimeter --> "+perimeter);
    }
}