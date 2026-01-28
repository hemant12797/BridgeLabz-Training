using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Method)]
class CacheResultAttribute : Attribute { }

class Calculator
{
    private Dictionary<int, int> cache = new Dictionary<int, int>();

    [CacheResult]
    public int Square(int x)
    {
        if (cache.ContainsKey(x))
            return cache[x];

        Console.WriteLine("Computing...");
        int result = x * x;
        cache[x] = result;
        return result;
    }
}

class CacheResultDemo
{
    static void Main()
    {
        Calculator c = new Calculator();
        Console.WriteLine(c.Square(5));
        Console.WriteLine(c.Square(5));
    }
}