using System;

namespace TrafficManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TrafficManager - Roundabout Vehicle Flow Simulator");
            Console.Write("Enter the maximum capacity for the waiting queue: ");
            int queueCapacity = int.Parse(Console.ReadLine());

            TrafficManager manager = new TrafficManager(queueCapacity);

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add vehicle to roundabout");
                Console.WriteLine("2. Remove vehicle from roundabout");
                Console.WriteLine("3. Add vehicle to waiting queue");
                Console.WriteLine("4. Move vehicle from queue to roundabout");
                Console.WriteLine("5. Print current state");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter vehicle license plate: ");
                        string addPlate = Console.ReadLine();
                        manager.AddVehicleToRoundabout(addPlate);
                        break;
                    case "2":
                        Console.Write("Enter vehicle license plate to remove: ");
                        string removePlate = Console.ReadLine();
                        manager.RemoveVehicleFromRoundabout(removePlate);
                        break;
                    case "3":
                        Console.Write("Enter vehicle license plate: ");
                        string queuePlate = Console.ReadLine();
                        manager.AddVehicleToQueue(queuePlate);
                        break;
                    case "4":
                        manager.MoveVehicleFromQueueToRoundabout();
                        break;
                    case "5":
                        manager.PrintState();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for using TrafficManager!");
        }
    }
}
