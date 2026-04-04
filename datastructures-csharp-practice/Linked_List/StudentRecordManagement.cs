using System;

public class Student
{
    public int RollNumber { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }

    public Student(int rollNumber, string name, int age, string grade)
    {
        RollNumber = rollNumber;
        Name = name;
        Age = age;
        Grade = grade;
    }
}

public class Node
{
    public Student Data { get; set; }
    public Node Next { get; set; }

    public Node(Student data)
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
    public void AddAtBeginning(Student student)
    {
        Node newNode = new Node(student);
        newNode.Next = head;
        head = newNode;
    }

    // Add at end
    public void AddAtEnd(Student student)
    {
        Node newNode = new Node(student);
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
    public void AddAtPosition(Student student, int position)
    {
        if (position < 0)
        {
            Console.WriteLine("Invalid position");
            return;
        }
        if (position == 0)
        {
            AddAtBeginning(student);
            return;
        }
        Node newNode = new Node(student);
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

    // Delete by Roll Number
    public void DeleteByRollNumber(int rollNumber)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        if (head.Data.RollNumber == rollNumber)
        {
            head = head.Next;
            return;
        }
        Node current = head;
        while (current.Next != null && current.Next.Data.RollNumber != rollNumber)
        {
            current = current.Next;
        }
        if (current.Next == null)
        {
            Console.WriteLine("Student not found");
            return;
        }
        current.Next = current.Next.Next;
    }

    // Search by Roll Number
    public Student SearchByRollNumber(int rollNumber)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.RollNumber == rollNumber)
            {
                return current.Data;
            }
            current = current.Next;
        }
        return null;
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
            Console.WriteLine($"Roll Number: {current.Data.RollNumber}, Name: {current.Data.Name}, Age: {current.Data.Age}, Grade: {current.Data.Grade}");
            current = current.Next;
        }
    }

    // Update grade by Roll Number
    public void UpdateGrade(int rollNumber, string newGrade)
    {
        Student student = SearchByRollNumber(rollNumber);
        if (student != null)
        {
            student.Grade = newGrade;
            Console.WriteLine("Grade updated successfully");
        }
        else
        {
            Console.WriteLine("Student not found");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SinglyLinkedList list = new SinglyLinkedList();

        // Add some students
        list.AddAtEnd(new Student(1, "Alice", 20, "A"));
        list.AddAtEnd(new Student(2, "Bob", 21, "B"));
        list.AddAtBeginning(new Student(0, "Charlie", 19, "A+"));

        Console.WriteLine("All students:");
        list.DisplayAll();

        // Search
        Student found = list.SearchByRollNumber(1);
        if (found != null)
        {
            Console.WriteLine($"Found: {found.Name}");
        }

        // Update grade
        list.UpdateGrade(2, "A");

        // Delete
        list.DeleteByRollNumber(0);

        Console.WriteLine("After operations:");
        list.DisplayAll();
    }
}
