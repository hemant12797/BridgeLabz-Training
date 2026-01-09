using System;
using System.Collections.Generic;

public class QueueUsingStacks<T>
{
    private Stack<T> enqueueStack;
    private Stack<T> dequeueStack;

    public QueueUsingStacks()
    {
        enqueueStack = new Stack<T>();
        dequeueStack = new Stack<T>();
    }

    // Enqueue operation: Push to enqueueStack
    public void Enqueue(T item)
    {
        enqueueStack.Push(item);
    }

    // Dequeue operation: If dequeueStack is empty, transfer from enqueueStack
    public T Dequeue()
    {
        if (dequeueStack.Count == 0)
        {
            TransferElements();
        }
        if (dequeueStack.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return dequeueStack.Pop();
    }

    // Peek operation: Similar to dequeue but without removing
    public T Peek()
    {
        if (dequeueStack.Count == 0)
        {
            TransferElements();
        }
        if (dequeueStack.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return dequeueStack.Peek();
    }

    // Check if queue is empty
    public bool IsEmpty()
    {
        return enqueueStack.Count == 0 && dequeueStack.Count == 0;
    }

    // Transfer elements from enqueueStack to dequeueStack
    private void TransferElements()
    {
        while (enqueueStack.Count > 0)
        {
            dequeueStack.Push(enqueueStack.Pop());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        QueueUsingStacks<int> queue = new QueueUsingStacks<int>();

        // Enqueue elements
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        // Dequeue and print
        Console.WriteLine(queue.Dequeue()); // 1
        Console.WriteLine(queue.Dequeue()); // 2

        // Enqueue more
        queue.Enqueue(4);

        // Peek
        Console.WriteLine(queue.Peek()); // 3

        // Dequeue remaining
        Console.WriteLine(queue.Dequeue()); // 3
        Console.WriteLine(queue.Dequeue()); // 4

        // Check if empty
        Console.WriteLine(queue.IsEmpty()); // True
    }
}
