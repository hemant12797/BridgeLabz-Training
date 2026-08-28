using Microsoft.EntityFrameworkCore;
using LabelManagement.Data;
using LabelManagement.Models;

namespace LabelManagement.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly LabelDbContext _context;

        public ReminderRepository(LabelDbContext context)
        {
            _context = context;
        }

        public async Task<ReminderModel> CreateReminderAsync(ReminderModel reminder)
        {
            await _context.Reminders.AddAsync(reminder);
            await _context.SaveChangesAsync();
            return reminder;
        }

        public async Task<ReminderModel?> GetReminderByIdAsync(int reminderId, int userId)
        {
            return await _context.Reminders
                .FirstOrDefaultAsync(r => r.ReminderId == reminderId && r.UserId == userId);
        }

        public async Task<IEnumerable<ReminderModel>> GetAllRemindersAsync(int userId)
        {
            return await _context.Reminders
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> DeleteReminderAsync(int reminderId, int userId)
        {
            var reminder = await _context.Reminders
                .FirstOrDefaultAsync(r => r.ReminderId == reminderId && r.UserId == userId);

            if (reminder == null) return false;

            _context.Reminders.Remove(reminder);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
