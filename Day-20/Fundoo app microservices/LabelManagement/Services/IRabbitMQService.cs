using LabelManagement.Models.DTOs;

namespace LabelManagement.Services
{
    public interface IRabbitMQService
    {
        Task PublishReminderAsync(ReminderMessage reminderMessage);
    }
}
