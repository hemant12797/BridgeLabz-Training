using System;

public class NumberOfRound{
    public static void Main(String[] args){
        Console.WriteLine("Enter first side :");
        int side1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter second side :");
        int side2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter third side :");
        int side3 = int.Parse(Console.ReadLine());

        // The perimeter of a triangle is the addition of all sides.

        int perimeter = side1 + side2 +side3;
        int distance = 5;
        float numberOfRounds = (float)perimeter / distance;

        Console.WriteLine("The total number of rounds the athlete will run is "+ numberOfRounds +" to complete 5 km");
    }
}