using System;
using System.Collections.Generic;

public class Process
{
    public int ProcessID { get; set; }
    public int BurstTime { get; set; }
    public int Priority { get; set; }
    public int RemainingTime { get; set; }
    public int WaitingTime { get; set; }
    public int TurnAroundTime { get; set; }

    public Process(int processID, int burstTime, int priority)
    {
        ProcessID = processID;
        BurstTime = burstTime;
        Priority = priority;
        RemainingTime = burstTime;
        WaitingTime = 0;
        TurnAroundTime = 0;
    }
}

public class CircularNode
{
    public Process Data { get; set; }
    public CircularNode Next { get; set; }

    public CircularNode(Process data)
    {
        Data = data;
        Next = null;
    }
}

public class CircularLinkedList
{
    private CircularNode head;
    private CircularNode tail;
    private int timeQuantum;

    public CircularLinkedList(int timeQuantum)
    {
        head = null;
        tail = null;
        this.timeQuantum = timeQuantum;
    }

    // Add a new process at the end
    public void AddProcess(Process process)
    {
        CircularNode newNode = new CircularNode(process);
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

    // Remove a process by Process ID
    public void RemoveProcess(int processID)
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
            if (current.Data.ProcessID == processID)
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
        Console.WriteLine("Process not found");
    }

    // Simulate round-robin scheduling
    public void SimulateRoundRobin()
    {
        if (head == null)
        {
            Console.WriteLine("No processes to schedule");
            return;
        }
        int currentTime = 0;
        CircularNode current = head;
        List<Process> completedProcesses = new List<Process>();
        do
        {
            if (current.Data.RemainingTime > 0)
            {
                int executeTime = Math.Min(timeQuantum, current.Data.RemainingTime);
                current.Data.RemainingTime -= executeTime;
                currentTime += executeTime;

                // Update waiting time for other processes
                CircularNode temp = current.Next;
                while (temp != current)
                {
                    if (temp.Data.RemainingTime > 0)
                    {
                        temp.Data.WaitingTime += executeTime;
                    }
                    temp = temp.Next;
                }

                if (current.Data.RemainingTime == 0)
                {
                    current.Data.TurnAroundTime = currentTime;
                    completedProcesses.Add(current.Data);
                    RemoveProcess(current.Data.ProcessID);
                }
            }
            current = current.Next;
            DisplayProcesses();
        } while (head != null && current != head);

        // Calculate averages
        double totalWaitingTime = 0;
        double totalTurnAroundTime = 0;
        foreach (Process p in completedProcesses)
        {
            totalWaitingTime += p.WaitingTime;
            totalTurnAroundTime += p.TurnAroundTime;
        }
        Console.WriteLine($"Average Waiting Time: {totalWaitingTime / completedProcesses.Count}");
        Console.WriteLine($"Average Turn-Around Time: {totalTurnAroundTime / completedProcesses.Count}");
    }

    // Display the list of processes
    public void DisplayProcesses()
    {
        if (head == null)
        {
            Console.WriteLine("No processes in the list");
            return;
        }
        CircularNode current = head;
        do
        {
            Console.WriteLine($"Process ID: {current.Data.ProcessID}, Remaining Time: {current.Data.RemainingTime}, Waiting Time: {current.Data.WaitingTime}");
            current = current.Next;
        } while (current != head);
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CircularLinkedList scheduler = new CircularLinkedList(3); // Time quantum = 3

        // Add processes
        scheduler.AddProcess(new Process(1, 10, 1));
        scheduler.AddProcess(new Process(2, 5, 2));
        scheduler.AddProcess(new Process(3, 8, 3));

        Console.WriteLine("Initial processes:");
        scheduler.DisplayProcesses();

        // Simulate scheduling
        scheduler.SimulateRoundRobin();
    }
}
