using System;
using System.Threading.Tasks;
using NotifyHub.Models;

namespace NotifyHub.Services
{
    public class EmailSender : INotificationSender
    {
        public async Task SendAsync(Notification notification)
        {
            await Task.Delay(1000);
            Console.WriteLine($"[EMAIL SENT] {notification.Message} to {notification.Recipient}");
        }
    }
}
