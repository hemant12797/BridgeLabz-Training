using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NotifyHub.Models;

namespace NotifyHub.Services
{
    public class NotificationProcessor
    {
        private readonly ConcurrentQueue<Notification> _queue = new();
        private readonly CancellationTokenSource _cts = new();

        public void Enqueue(Notification notification)
        {
            if (string.IsNullOrWhiteSpace(notification.NotificationId))
            {
                Console.WriteLine("Invalid: NotificationId required.");
                return;
            }

            _queue.Enqueue(notification);
            Console.WriteLine($"Enqueued: {notification.NotificationId}");
        }

        public void StartProcessing()
        {
            Task.Run(ProcessAsync);
        }

        private async Task ProcessAsync()
        {
            while (!_cts.Token.IsCancellationRequested)
            {
                if (_queue.TryDequeue(out var notification))
                {
                    try
                    {
                        INotificationSender sender = notification.Type switch
                        {
                            "Email" => new EmailSender(),
                            "SMS" => new SmsSender(),
                            _ => throw new Exception("Unknown type")
                        };

                        await sender.SendAsync(notification);
                        notification.Status = "Sent";
                    }
                    catch (Exception ex)
                    {
                        notification.Status = "Failed";
                        Console.WriteLine($"Error sending {notification.NotificationId}: {ex.Message}");
                    }
                }
                else
                {
                    await Task.Delay(500);
                }
            }
        }

        public void Stop() => _cts.Cancel();
    }
}
