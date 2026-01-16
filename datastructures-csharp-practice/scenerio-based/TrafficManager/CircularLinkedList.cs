using System;

namespace TrafficManager
{
    public class CircularLinkedList
    {
        public Vehicle Head { get; private set; }
        public int Count { get; private set; }

        public CircularLinkedList()
        {
            Head = null;
            Count = 0;
        }

        public void AddVehicle(string licensePlate)
        {
            Vehicle newVehicle = new Vehicle(licensePlate);
            if (Head == null)
            {
                Head = newVehicle;
                Head.Next = Head; // Point to itself
            }
            else
            {
                Vehicle temp = Head;
                while (temp.Next != Head)
                {
                    temp = temp.Next;
                }
                temp.Next = newVehicle;
                newVehicle.Next = Head;
            }
            Count++;
        }

        public bool RemoveVehicle(string licensePlate)
        {
            if (Head == null) return false;

            Vehicle current = Head;
            Vehicle previous = null;

            do
            {
                if (current.LicensePlate == licensePlate)
                {
                    if (previous == null) // Removing head
                    {
                        if (Count == 1)
                        {
                            Head = null;
                        }
                        else
                        {
                            Vehicle temp = Head;
                            while (temp.Next != Head)
                            {
                                temp = temp.Next;
                            }
                            Head = Head.Next;
                            temp.Next = Head;
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            } while (current != Head);

            return false;
        }

        public void PrintRoundabout()
        {
            if (Head == null)
            {
                Console.WriteLine("Roundabout is empty.");
                return;
            }

            Console.Write("Roundabout: ");
            Vehicle current = Head;
            do
            {
                Console.Write(current.LicensePlate + " -> ");
                current = current.Next;
            } while (current != Head);
            Console.WriteLine("(back to start)");
        }
    }
}
