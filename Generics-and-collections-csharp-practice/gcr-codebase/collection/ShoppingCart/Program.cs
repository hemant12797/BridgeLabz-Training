using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        // Dictionary<string, double> to store product prices
        Dictionary<string, double> productPrices = new Dictionary<string, double>()
        {
            { "Apple", 1.0 },
            { "Banana", 0.5 },
            { "Orange", 1.5 },
            { "Milk", 2.0 },
            { "Bread", 1.2 }
        };

        // OrderedDictionary to maintain order of added items
        OrderedDictionary cart = new OrderedDictionary();

        // SortedDictionary<double, string> to display items sorted by price
        SortedDictionary<double, string> sortedCart = new SortedDictionary<double, string>();

        // Simulate adding items to cart
        AddToCart(cart, sortedCart, "Apple", productPrices["Apple"]);
        AddToCart(cart, sortedCart, "Banana", productPrices["Banana"]);
        AddToCart(cart, sortedCart, "Orange", productPrices["Orange"]);
        AddToCart(cart, sortedCart, "Milk", productPrices["Milk"]);
        AddToCart(cart, sortedCart, "Bread", productPrices["Bread"]);

        // Display cart in the order items were added
        Console.WriteLine("Shopping Cart (Order Added):");
        foreach (DictionaryEntry entry in cart)
        {
            Console.WriteLine($"{entry.Key}: ${entry.Value}");
        }

        // Display cart sorted by price
        Console.WriteLine("\nShopping Cart (Sorted by Price):");
        foreach (var entry in sortedCart)
        {
            Console.WriteLine($"{entry.Value}: ${entry.Key}");
        }
    }

    static void AddToCart(OrderedDictionary cart, SortedDictionary<double, string> sortedCart, string item, double price)
    {
        cart.Add(item, price);
        sortedCart[price] = item; // Note: Assumes unique prices; if prices are not unique, this will overwrite
    }
}
