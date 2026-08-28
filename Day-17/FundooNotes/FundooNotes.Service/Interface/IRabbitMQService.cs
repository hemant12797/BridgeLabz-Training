using FundooNotes.Models.DTOs;

namespace FundooNotes.Service.Interface
{
    public interface IRabbitMQService
    {
        Task PublishReminderAsync(ReminderMessage reminderMessage);
    }
}
