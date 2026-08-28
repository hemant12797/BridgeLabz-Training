using FundooNotes.Models.Entities;
using FundooNotes.Models.DTOs;

namespace FundooNotes.Service.Interface
{
    public interface IReminderService
    {
        Task<ReminderModel> CreateReminderAsync(CreateReminderDto dto, int userId);
        Task<ReminderModel?> GetReminderByIdAsync(int reminderId, int userId);
        Task<IEnumerable<ReminderModel>> GetAllRemindersAsync(int userId);
        Task<bool> DeleteReminderAsync(int reminderId, int userId);
    }
}
