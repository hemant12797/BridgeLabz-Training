using System;
using System.Collections.Generic;

class Node
{
    public string Key { get; set; }
    public string Value { get; set; }
    public Node Next { get; set; }

    public Node(string key, string value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}

class CustomHashMap
{
    private const int SIZE = 10;
    private Node[] table;

    public CustomHashMap()
    {
        table = new Node[SIZE];
    }

    private int GetHash(string key)
    {
        return Math.Abs(key.GetHashCode()) % SIZE;
    }

    public void Put(string key, string value)
    {
        int hash = GetHash(key);
        Node node = table[hash];

        while (node != null)
        {
            if (node.Key.Equals(key))
            {
                node.Value = value; // Update value if key exists
                return;
            }
            node = node.Next;
        }

        // Insert new node at the beginning
        Node newNode = new Node(key, value);
        newNode.Next = table[hash];
        table[hash] = newNode;
    }

    public string Get(string key)
    {
        int hash = GetHash(key);
        Node node = table[hash];

        while (node != null)
        {
            if (node.Key.Equals(key))
            {
                return node.Value;
            }
            node = node.Next;
        }

        return null; // Key not found
    }

    public void Remove(string key)
    {
        int hash = GetHash(key);
        Node node = table[hash];
        Node prev = null;

        while (node != null)
        {
            if (node.Key.Equals(key))
            {
                if (prev == null)
                {
                    table[hash] = node.Next;
                }
                else
                {
                    prev.Next = node.Next;
                }
                return;
            }
            prev = node;
            node = node.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        CustomHashMap map = new CustomHashMap();

        // Insert operations
        map.Put("key1", "value1");
        map.Put("key2", "value2");
        map.Put("key3", "value3");

        // Retrieve operations
        Console.WriteLine("key1: " + map.Get("key1"));
        Console.WriteLine("key2: " + map.Get("key2"));
        Console.WriteLine("key4: " + map.Get("key4")); // Non-existent

        // Update operation
        map.Put("key1", "updated_value1");
        Console.WriteLine("key1 after update: " + map.Get("key1"));

        // Delete operation
        map.Remove("key2");
        Console.WriteLine("key2 after removal: " + map.Get("key2"));
    }
}
