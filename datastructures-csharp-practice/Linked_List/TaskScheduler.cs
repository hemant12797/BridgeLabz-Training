using System;

public class Task
{
    public int TaskID { get; set; }
    public string TaskName { get; set; }
    public int Priority { get; set; }
    public DateTime DueDate { get; set; }

    public Task(int taskID, string taskName, int priority, DateTime dueDate)
    {
        TaskID = taskID;
        TaskName = taskName;
        Priority = priority;
        DueDate = dueDate;
    }
}

public class CircularNode
{
    public Task Data { get; set; }
    public CircularNode Next { get; set; }

    public CircularNode(Task data)
    {
        Data = data;
        Next = null;
    }
}

public class CircularLinkedList
{
    private CircularNode head;
    private CircularNode tail;

    public CircularLinkedList()
    {
        head = null;
        tail = null;
    }

    // Add at beginning
    public void AddAtBeginning(Task task)
    {
        CircularNode newNode = new CircularNode(task);
        if (head == null)
        {
            head = tail = newNode;
            tail.Next = head;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
            tail.Next = head;
        }
    }

    // Add at end
    public void AddAtEnd(Task task)
    {
        CircularNode newNode = new CircularNode(task);
        if (head == null)
        {
            head = tail = newNode;
            tail.Next = head;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
            tail.Next = head;
        }
    }

    // Add at specific position
    public void AddAtPosition(Task task, int position)
    {
        if (position < 0)
        {
            Console.WriteLine("Invalid position");
            return;
        }
        if (position == 0)
        {
            AddAtBeginning(task);
            return;
        }
        CircularNode newNode = new CircularNode(task);
        CircularNode current = head;
        int count = 0;
        while (count < position - 1 && current.Next != head)
        {
            current = current.Next;
            count++;
        }
        if (count < position - 1)
        {
            Console.WriteLine("Position out of range");
            return;
        }
        newNode.Next = current.Next;
        current.Next = newNode;
        if (current == tail)
        {
            tail = newNode;
        }
    }

    // Remove by Task ID
    public void RemoveByTaskID(int taskID)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        CircularNode current = head;
        CircularNode prev = null;
        do
        {
            if (current.Data.TaskID == taskID)
            {
                if (current == head && current == tail)
                {
                    head = tail = null;
                }
                else if (current == head)
                {
                    head = head.Next;
                    tail.Next = head;
                }
                else if (current == tail)
                {
                    tail = prev;
                    tail.Next = head;
                }
                else
                {
                    prev.Next = current.Next;
                }
                return;
            }
            prev = current;
            current = current.Next;
        } while (current != head);
        Console.WriteLine("Task not found");
    }

    // View current task and move to next
    public Task ViewCurrentAndMoveNext()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return null;
        }
        Task currentTask = head.Data;
        head = head.Next;
        tail = tail.Next;
        return currentTask;
    }

    // Display all starting from head
    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        CircularNode current = head;
        do
        {
            Console.WriteLine($"Task ID: {current.Data.TaskID}, Name: {current.Data.TaskName}, Priority: {current.Data.Priority}, Due Date: {current.Data.DueDate}");
            current = current.Next;
        } while (current != head);
    }

    // Search by Priority
    public Task SearchByPriority(int priority)
    {
        if (head == null)
        {
            return null;
        }
        CircularNode current = head;
        do
        {
            if (current.Data.Priority == priority)
            {
                return current.Data;
            }
            current = current.Next;
        } while (current != head);
        return null;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CircularLinkedList list = new CircularLinkedList();

        // Add some tasks
        list.AddAtEnd(new Task(1, "Task 1", 1, DateTime.Now.AddDays(1)));
        list.AddAtEnd(new Task(2, "Task 2", 2, DateTime.Now.AddDays(2)));
        list.AddAtBeginning(new Task(0, "Task 0", 0, DateTime.Now));

        Console.WriteLine("All tasks:");
        list.DisplayAll();

        // Search
        Task found = list.SearchByPriority(1);
        if (found != null)
        {
            Console.WriteLine($"Found: {found.TaskName}");
        }

        // View current and move
        Task current = list.ViewCurrentAndMoveNext();
        if (current != null)
        {
            Console.WriteLine($"Current task: {current.TaskName}");
        }

        // Remove
        list.RemoveByTaskID(1);

        Console.WriteLine("After operations:");
        list.DisplayAll();
    }
}
