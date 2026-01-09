using System;

public class Item
{
    public string Name { get; set; }
    public int ItemID { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Item(string name, int itemID, int quantity, double price)
    {
        Name = name;
        ItemID = itemID;
        Quantity = quantity;
        Price = price;
    }
}

public class Node
{
    public Item Data { get; set; }
    public Node Next { get; set; }

    public Node(Item data)
    {
        Data = data;
        Next = null;
    }
}

public class SinglyLinkedList
{
    private Node head;

    public SinglyLinkedList()
    {
        head = null;
    }

    // Add at beginning
    public void AddAtBeginning(Item item)
    {
        Node newNode = new Node(item);
        newNode.Next = head;
        head = newNode;
    }

    // Add at end
    public void AddAtEnd(Item item)
    {
        Node newNode = new Node(item);
        if (head == null)
        {
            head = newNode;
            return;
        }
        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    // Add at specific position
    public void AddAtPosition(Item item, int position)
    {
        if (position < 0)
        {
            Console.WriteLine("Invalid position");
            return;
        }
        if (position == 0)
        {
            AddAtBeginning(item);
            return;
        }
        Node newNode = new Node(item);
        Node current = head;
        int count = 0;
        while (current != null && count < position - 1)
        {
            current = current.Next;
            count++;
        }
        if (current == null)
        {
            Console.WriteLine("Position out of range");
            return;
        }
        newNode.Next = current.Next;
        current.Next = newNode;
    }

    // Remove by Item ID
    public void RemoveByItemID(int itemID)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        if (head.Data.ItemID == itemID)
        {
            head = head.Next;
            return;
        }
        Node current = head;
        while (current.Next != null && current.Next.Data.ItemID != itemID)
        {
            current = current.Next;
        }
        if (current.Next == null)
        {
            Console.WriteLine("Item not found");
            return;
        }
        current.Next = current.Next.Next;
    }

    // Update quantity by Item ID
    public void UpdateQuantity(int itemID, int newQuantity)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.ItemID == itemID)
            {
                current.Data.Quantity = newQuantity;
                Console.WriteLine("Quantity updated successfully");
                return;
            }
            current = current.Next;
        }
        Console.WriteLine("Item not found");
    }

    // Search by Item ID
    public Item SearchByItemID(int itemID)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.ItemID == itemID)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null;
    }

    // Search by Item Name
    public Item SearchByItemName(string name)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Name == name)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null;
    }

    // Calculate total value
    public double CalculateTotalValue()
    {
        double total = 0;
        Node current = head;
        while (current != null)
        {
            total += current.Data.Quantity * current.Data.Price;
            current = current.Next;
        }
        return total;
    }

    // Sort by Item Name ascending
    public void SortByNameAscending()
    {
        if (head == null || head.Next == null)
        {
            return;
        }
        bool swapped;
        do
        {
            swapped = false;
            Node current = head;
            while (current.Next != null)
            {
                if (string.Compare(current.Data.Name, current.Next.Data.Name) > 0)
                {
                    Item temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);
    }

    // Sort by Price ascending
    public void SortByPriceAscending()
    {
        if (head == null || head.Next == null)
        {
            return;
        }
        bool swapped;
        do
        {
            swapped = false;
            Node current = head;
            while (current.Next != null)
            {
                if (current.Data.Price > current.Next.Data.Price)
                {
                    Item temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);
    }

    // Display all
    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        Node current = head;
        while (current != null)
        {
            Console.WriteLine($"Name: {current.Data.Name}, ID: {current.Data.ItemID}, Quantity: {current.Data.Quantity}, Price: {current.Data.Price}");
            current = current.Next;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SinglyLinkedList list = new SinglyLinkedList();

        // Add some items
        list.AddAtEnd(new Item("Apple", 1, 10, 2.5));
        list.AddAtEnd(new Item("Banana", 2, 20, 1.0));
        list.AddAtBeginning(new Item("Cherry", 0, 5, 3.0));

        Console.WriteLine("All items:");
        list.DisplayAll();

        // Search
        Item found = list.SearchByItemID(1);
        if (found != null)
        {
            Console.WriteLine($"Found: {found.Name}");
        }

        // Update quantity
        list.UpdateQuantity(2, 25);

        // Calculate total value
        Console.WriteLine($"Total value: {list.CalculateTotalValue()}");

        // Sort by name
        list.SortByNameAscending();
        Console.WriteLine("Sorted by name:");
        list.DisplayAll();

        // Remove
        list.RemoveByItemID(0);

        Console.WriteLine("After operations:");
        list.DisplayAll();
    }
}
