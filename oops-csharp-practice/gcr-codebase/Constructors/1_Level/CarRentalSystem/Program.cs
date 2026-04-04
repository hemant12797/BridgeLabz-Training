using System;

class Program
{
    static void Main()
    {
        CarRental cr = new CarRental("Ashish", "Swift", 5);
        Console.WriteLine("Total Cost: " + cr.TotalCost());
    }
}
