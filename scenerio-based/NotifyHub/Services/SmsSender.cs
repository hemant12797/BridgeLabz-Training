using System;
using System.Threading.Tasks;
using NotifyHub.Models;

namespace NotifyHub.Services
{
    public class SmsSender : INotificationSender
    {
        public async Task SendAsync(Notification notification)
        {
            await Task.Delay(800);
            Console.WriteLine($"[SMS SENT] {notification.Message} to {notification.Recipient}");
        }
    }
}
