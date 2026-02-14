using System;
using System.Threading.Tasks;
using NotifyHub.Models;
using NotifyHub.Services;

namespace NotifyHub
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var processor = new NotificationProcessor();
            processor.StartProcessing();

            Parallel.For(1, 6, i =>
            {
                processor.Enqueue(new EmailNotification
                {
                    NotificationId = Guid.NewGuid().ToString(),
                    Recipient = "user@example.com",
                    Message = $"Email Notification {i}",
                    Priority = NotificationPriority.High
                });

                processor.Enqueue(new SmsNotification
                {
                    NotificationId = Guid.NewGuid().ToString(),
                    Recipient = "9999999999",
                    Message = $"SMS Notification {i}",
                    Priority = NotificationPriority.Medium
                });
            });

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            processor.Stop();
        }
    }
}
