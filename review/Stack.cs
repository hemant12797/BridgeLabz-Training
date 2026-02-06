using System;

class Stack
{
    int MAX = 100;
    int[] arr;
    int top;

    public Stack()
    {
        arr = new int[MAX];
        top = -1;
    }

    public void Push(int x)
    {
        arr[++top] = x;
    }

    public int Pop()
    {
        return arr[top--];
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public void InsertAtBottom(int x)
    {
        if (IsEmpty())
        {
            Push(x);
            return;
        }

        int temp = Pop();
        InsertAtBottom(x);
        Push(temp);
    }

    //recursion
    public void ReverseStack()
    {
        if (IsEmpty())
            return;

        int temp = Pop();
        ReverseStack();
        InsertAtBottom(temp);
    }

    public void Display()
    {
        for (int i = top; i >= 0; i--)
        {
            Console.WriteLine(arr[i]);
        }
    }

    static void Main(string[] args)
    {
        Stack s = new Stack();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int value = int.Parse(Console.ReadLine());
            s.Push(value);
        }
        s.Display();

        s.ReverseStack();

        Console.WriteLine("------------reverse stack-----");
        s.Display();
        Console.WriteLine("_________________________NORMAL DISPLAY_______________________________");
        s.Display();
    }
}
