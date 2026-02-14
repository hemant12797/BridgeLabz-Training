using System.Threading.Tasks;
using NotifyHub.Models;

namespace NotifyHub.Services
{
    public interface INotificationSender
    {
        Task SendAsync(Notification notification);
    }
}
