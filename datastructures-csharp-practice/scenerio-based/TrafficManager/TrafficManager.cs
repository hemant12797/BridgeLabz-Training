using System;

namespace TrafficManager
{
    public class TrafficManager
    {
        private CircularLinkedList roundabout;
        private VehicleQueue waitingQueue;

        public TrafficManager(int queueCapacity)
        {
            roundabout = new CircularLinkedList();
            waitingQueue = new VehicleQueue(queueCapacity);
        }

        public void AddVehicleToRoundabout(string licensePlate)
        {
            roundabout.AddVehicle(licensePlate);
            Console.WriteLine($"Vehicle {licensePlate} added to roundabout.");
        }

        public void RemoveVehicleFromRoundabout(string licensePlate)
        {
            if (roundabout.RemoveVehicle(licensePlate))
            {
                Console.WriteLine($"Vehicle {licensePlate} removed from roundabout.");
            }
            else
            {
                Console.WriteLine($"Vehicle {licensePlate} not found in roundabout.");
            }
        }

        public void AddVehicleToQueue(string licensePlate)
        {
            if (waitingQueue.Enqueue(licensePlate))
            {
                Console.WriteLine($"Vehicle {licensePlate} added to waiting queue.");
            }
            else
            {
                Console.WriteLine("Waiting queue is full. Cannot add vehicle.");
            }
        }

        public void MoveVehicleFromQueueToRoundabout()
        {
            Vehicle vehicle = waitingQueue.Dequeue();
            if (vehicle != null)
            {
                roundabout.AddVehicle(vehicle.LicensePlate);
                Console.WriteLine($"Vehicle {vehicle.LicensePlate} moved from queue to roundabout.");
            }
            else
            {
                Console.WriteLine("Waiting queue is empty. No vehicle to move.");
            }
        }

        public void PrintState()
        {
            roundabout.PrintRoundabout();
            waitingQueue.PrintQueue();
        }
    }
}
