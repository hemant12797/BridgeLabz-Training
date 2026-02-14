
using System;
using NotifyHub.Models;
using NotifyHub.Services;

namespace NotifyHub
{
    class Program
    {
        static void Main()
        {
            var processor = new NotificationProcessor();
            processor.Start();

            while (true)
            {
                Console.WriteLine("\n1. Add Notification");
                Console.WriteLine("2. Exit");
                Console.Write("Choose option: ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    var notification = new Notification();

                    Console.Write("Enter Type (Email/SMS): ");
                    notification.Type = Console.ReadLine() ?? "";

                    Console.Write("Enter Recipient: ");
                    notification.Recipient = Console.ReadLine() ?? "";

                    Console.Write("Enter Message: ");
                    notification.Message = Console.ReadLine() ?? "";

                    Console.Write("Priority (1-Low,2-Medium,3-High): ");
                    notification.Priority = (Priority)int.Parse(Console.ReadLine() ?? "1");

                    processor.Enqueue(notification);
                }
                else if (choice == "2")
                {
                    processor.Stop();
                    break;
                }
            }
        }
    }
}