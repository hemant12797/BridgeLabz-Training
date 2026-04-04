using System;
using System.Collections.Generic;

namespace TrafficManager
{
    public class VehicleQueue
    {
        private List<Vehicle> queue;
        private int maxCapacity;

        public VehicleQueue(int capacity)
        {
            queue = new List<Vehicle>();
            maxCapacity = capacity;
        }

        public bool Enqueue(string licensePlate)
        {
            if (queue.Count >= maxCapacity)
            {
                Console.WriteLine("Queue overflow: Cannot add more vehicles. Queue is full.");
                return false;
            }
            Vehicle newVehicle = new Vehicle(licensePlate);
            queue.Add(newVehicle);
            return true;
        }

        public Vehicle Dequeue()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Queue underflow: No vehicles in the queue.");
                return null;
            }
            Vehicle vehicle = queue[0];
            queue.RemoveAt(0);
            return vehicle;
        }

        public void PrintQueue()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }
            Console.Write("Queue: ");
            foreach (var vehicle in queue)
            {
                Console.Write(vehicle.LicensePlate + " ");
            }
            Console.WriteLine();
        }

        public int Count => queue.Count;
    }
}
