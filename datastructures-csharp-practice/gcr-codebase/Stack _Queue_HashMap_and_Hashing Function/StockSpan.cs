using System;
using System.Collections.Generic;

public class StockSpan
{
    public int[] CalculateSpan(int[] prices)
    {
        int n = prices.Length;
        int[] spans = new int[n];
        Stack<int> stack = new Stack<int>();
        stack.Push(-1);

        for (int i = 0; i < n; i++)
        {
            while (stack.Peek() != -1 && prices[stack.Peek()] <= prices[i])
            {
                stack.Pop();
            }
            spans[i] = i - stack.Peek();
            stack.Push(i);
        }
        return spans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] prices = { 100, 80, 60, 70, 60, 75, 85 };
        StockSpan stockSpan = new StockSpan();
        int[] spans = stockSpan.CalculateSpan(prices);

        Console.WriteLine("Spans: " + string.Join(", ", spans));
    }
}
