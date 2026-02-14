
using System;
using System.Collections.Concurrent;
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
            _queue.Enqueue(notification);
            Console.WriteLine("Notification added successfully.");
        }

        public void Start()
        {
            Task.Run(ProcessAsync);
        }

        private async Task ProcessAsync()
        {
            while (!_cts.Token.IsCancellationRequested)
            {
                if (_queue.TryDequeue(out var n))
                {
                    try
                    {
                        await Task.Delay(1000);
                        n.Status = "Sent";
                        Console.WriteLine($"Sent [{n.Type}] to {n.Recipient}");
                    }
                    catch (Exception ex)
                    {
                        n.Status = "Failed";
                        Console.WriteLine($"Error: {ex.Message}");
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
