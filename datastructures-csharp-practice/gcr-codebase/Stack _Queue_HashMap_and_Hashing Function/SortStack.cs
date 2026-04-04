using System;
using System.Collections.Generic;

public class SortStack<T> where T : IComparable<T>
{
    public void Sort(Stack<T> stack)
    {
        if (stack.Count > 0)
        {
            T temp = stack.Pop();
            Sort(stack);
            InsertSorted(stack, temp);
        }
    }

    private void InsertSorted(Stack<T> stack, T item)
    {
        if (stack.Count == 0 || item.CompareTo(stack.Peek()) >= 0)
        {
            stack.Push(item);
        }
        else
        {
            T temp = stack.Pop();
            InsertSorted(stack, item);
            stack.Push(temp);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(3);
        stack.Push(1);
        stack.Push(4);
        stack.Push(2);

        SortStack<int> sorter = new SortStack<int>();
        sorter.Sort(stack);

        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}
