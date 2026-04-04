using System;

public class SideOfSquare
{
    public static void Main(String[] args)
    {
        Console.Write("Enter the perimeter of the square: ");
        float perimeter = float.Parse(Console.ReadLine());

        // Side of square = Perimeter / 4
        float side = perimeter / 4;

        Console.WriteLine("The length of the side is " + side + " whose perimeter is " + perimeter);
    }
}