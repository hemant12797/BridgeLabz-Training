using System;

public class AreaOfTriangle
{
    public static void Main(String[] args)
    {
        Console.Write("Enter base of triangle :");
        float baseOfTri = float.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("Enter height of triangle :");
        float height = float.Parse(Console.ReadLine());
        Console.WriteLine();

        // Area of a Triangle is ½ * base * height

        //area of a triangle in square inches and square centimeters
        float areaininches = 0.5f * baseOfTri * height;
        float areaincentimeters = areaininches * 6.4516f;  //2.54*2 = 6.4516
        Console.WriteLine("The area of triangle with base "+ baseOfTri +" and height "+ height +" is "+ areaininches + " square inches and " + areaincentimeters + " square centimeters");

    }
}