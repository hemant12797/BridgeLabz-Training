using System;
using System.Collections.Generic;

public class Customer
{
    public string Name { get; set; }
    public List<string> Items { get; set; }

    public Customer(string name, List<string> items)
    {
        Name = name;
        Items = items;
    }

    public override string ToString() => $"{Name} with items: {string.Join(", ", Items)}";
}

public class SmartCheckout
{
    private Queue<Customer> checkoutQueue = new Queue<Customer>();
    private Dictionary<string, (int price, int stock)> itemMap = new Dictionary<string, (int, int)>();

    public SmartCheckout()
    {
        // Initialize some sample items
        itemMap["Apple"] = (2, 100);
        itemMap["Banana"] = (1, 150);
        itemMap["Milk"] = (3, 50);
        itemMap["Bread"] = (4, 30);
    }

    public void AddCustomer(Customer customer)
    {
        checkoutQueue.Enqueue(customer);
        Console.WriteLine($"Added {customer.Name} to the queue.");
    }

    public void ProcessCustomer()
    {
        if (checkoutQueue.Count == 0)
        {
            Console.WriteLine("No customers in the queue.");
            return;
        }

        Customer customer = checkoutQueue.Dequeue();
        Console.WriteLine($"Processing {customer.Name}...");

        int total = 0;
        foreach (var item in customer.Items)
        {
            if (itemMap.ContainsKey(item))
            {
                var (price, stock) = itemMap[item];
                if (stock > 0)
                {
                    total += price;
                    itemMap[item] = (price, stock - 1);
                    Console.WriteLine($"  {item}: ${price} (Stock left: {stock - 1})");
                }
                else
                {
                    Console.WriteLine($"  {item}: Out of stock!");
                }
            }
            else
            {
                Console.WriteLine($"  {item}: Item not found!");
            }
        }

        Console.WriteLine($"Total for {customer.Name}: ${total}");
    }

    public int GetItemPrice(string item)
    {
        if (itemMap.ContainsKey(item))
        {
            return itemMap[item].price;
        }
        return -1; // Not found
    }

    public void DisplayQueue()
    {
        Console.WriteLine("Current queue:");
        foreach (var customer in checkoutQueue)
        {
            Console.WriteLine($"  {customer}");
        }
    }

    public void DisplayStock()
    {
        Console.WriteLine("Current stock:");
        foreach (var kvp in itemMap)
        {
            Console.WriteLine($"  {kvp.Key}: Price ${kvp.Value.price}, Stock {kvp.Value.stock}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SmartCheckout checkout = new SmartCheckout();

        // Add customers
        checkout.AddCustomer(new Customer("Alice", new List<string> { "Apple", "Banana" }));
        checkout.AddCustomer(new Customer("Bob", new List<string> { "Milk", "Bread" }));
        checkout.AddCustomer(new Customer("Charlie", new List<string> { "Apple", "Milk" }));

        checkout.DisplayQueue();
        checkout.DisplayStock();

        // Process customers
        checkout.ProcessCustomer();
        checkout.ProcessCustomer();
        checkout.ProcessCustomer();

        checkout.DisplayStock();
    }
}
