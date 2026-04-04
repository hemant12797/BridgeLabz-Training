using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<int, int> Dispense(int amount, List<int> denominations)
    {
        var result = new Dictionary<int, int>();
        denominations.Sort((a, b) => b.CompareTo(a)); // descending
        foreach (var note in denominations)
        {
            if (amount >= note)
            {
                int count = amount / note;
                result[note] = count;
                amount -= count * note;
            }
        }
        return result;
    }

    static void Main()
    {
        // Scenario A: All denominations for ₹880
        var denomsA = new List<int> { 1, 2, 5, 10, 20, 50, 100, 200, 500 };
        var comboA = Dispense(880, denomsA);
        Console.WriteLine("Scenario A:");
        foreach (var kv in comboA)
        {
            Console.WriteLine($"{kv.Value} x ₹{kv.Key}");
        }
        Console.WriteLine();

        // Scenario B: Without ₹500 for ₹880
        var denomsB = new List<int> { 1, 2, 5, 10, 20, 50, 100, 200 };
        var comboB = Dispense(880, denomsB);
        Console.WriteLine("Scenario B:");
        foreach (var kv in comboB)
        {
            Console.WriteLine($"{kv.Value} x ₹{kv.Key}");
        }
        Console.WriteLine();

        // Scenario C: Fallback if exact change not possible (using ₹881 without ₹1, ₹2)
        var denomsC = new List<int> { 5, 10, 20, 50, 100, 200, 500 };
        int amountC = 881;
        var comboC = Dispense(amountC, denomsC);
        Console.WriteLine("Scenario C:");
        foreach (var kv in comboC)
        {
            Console.WriteLine($"{kv.Value} x ₹{kv.Key}");
        }
        int remaining = amountC;
        foreach (var kv in comboC)
        {
            remaining -= kv.Key * kv.Value;
        }
        if (remaining > 0)
        {
            Console.WriteLine($"Fallback combo, remaining ₹{remaining}");
        }
    }
}
