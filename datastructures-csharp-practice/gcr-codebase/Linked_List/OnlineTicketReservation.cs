using System;

public class Ticket
{
    public int TicketID { get; set; }
    public string CustomerName { get; set; }
    public string MovieName { get; set; }
    public string SeatNumber { get; set; }
    public DateTime BookingTime { get; set; }

    public Ticket(int ticketID, string customerName, string movieName, string seatNumber, DateTime bookingTime)
    {
        TicketID = ticketID;
        CustomerName = customerName;
        MovieName = movieName;
        SeatNumber = seatNumber;
        BookingTime = bookingTime;
    }
}

public class CircularNode
{
    public Ticket Data { get; set; }
    public CircularNode Next { get; set; }

    public CircularNode(Ticket data)
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

    // Add a new ticket at the end
    public void AddTicket(Ticket ticket)
    {
        CircularNode newNode = new CircularNode(ticket);
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

    // Remove a ticket by Ticket ID
    public void RemoveTicket(int ticketID)
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
            if (current.Data.TicketID == ticketID)
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
        Console.WriteLine("Ticket not found");
    }

    // Display current tickets
    public void DisplayTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets in the list");
            return;
        }
        CircularNode current = head;
        do
        {
            Console.WriteLine($"Ticket ID: {current.Data.TicketID}, Customer: {current.Data.CustomerName}, Movie: {current.Data.MovieName}, Seat: {current.Data.SeatNumber}, Time: {current.Data.BookingTime}");
            current = current.Next;
        } while (current != head);
    }

    // Search by Customer Name
    public Ticket SearchByCustomerName(string customerName)
    {
        if (head == null)
        {
            return null;
        }
        CircularNode current = head;
        do
        {
            if (current.Data.CustomerName == customerName)
            {
                return current.Data;
            }
            current = current.Next;
        } while (current != head);
        return null;
    }

    // Search by Movie Name
    public Ticket SearchByMovieName(string movieName)
    {
        if (head == null)
        {
            return null;
        }
        CircularNode current = head;
        do
        {
            if (current.Data.MovieName == movieName)
            {
                return current.Data;
            }
            current = current.Next;
        } while (current != head);
        return null;
    }

    // Calculate total number of booked tickets
    public int TotalBookedTickets()
    {
        if (head == null)
        {
            return 0;
        }
        int count = 0;
        CircularNode current = head;
        do
        {
            count++;
            current = current.Next;
        } while (current != head);
        return count;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CircularLinkedList system = new CircularLinkedList();

        // Add some tickets
        system.AddTicket(new Ticket(1, "Alice", "Inception", "A1", DateTime.Now));
        system.AddTicket(new Ticket(2, "Bob", "The Dark Knight", "B2", DateTime.Now));
        system.AddTicket(new Ticket(3, "Charlie", "Inception", "A2", DateTime.Now));

        Console.WriteLine("All tickets:");
        system.DisplayTickets();

        // Search
        Ticket found = system.SearchByCustomerName("Alice");
        if (found != null)
        {
            Console.WriteLine($"Found ticket for {found.CustomerName}");
        }

        // Total tickets
        Console.WriteLine($"Total booked tickets: {system.TotalBookedTickets()}");

        // Remove
        system.RemoveTicket(2);

        Console.WriteLine("After removal:");
        system.DisplayTickets();
    }
}
