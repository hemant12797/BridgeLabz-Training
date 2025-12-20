using System;

public class CalculateTotalPrice
{
    public static void Main(String[] args)
    {
        Console.Write("Enter the price of the item: ");
        float price = float.Parse(Console.ReadLine());

        Console.Write("Enter the quantity of the item: ");
        int quantity = int.Parse(Console.ReadLine());

        // Total Price = Price * Quantity
        float totalPrice = price * quantity;

        Console.WriteLine("The total price for " + quantity + " items at a price of " + price + " each is: " + totalPrice);
    }
}