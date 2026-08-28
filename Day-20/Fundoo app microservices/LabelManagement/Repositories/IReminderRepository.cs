using LabelManagement.Models;

namespace LabelManagement.Repositories
{
    public interface IReminderRepository
    {
        Task<ReminderModel> CreateReminderAsync(ReminderModel reminder);
        Task<ReminderModel?> GetReminderByIdAsync(int reminderId, int userId);
        Task<IEnumerable<ReminderModel>> GetAllRemindersAsync(int userId);
        Task<bool> DeleteReminderAsync(int reminderId, int userId);
    }
}
