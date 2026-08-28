using Microsoft.EntityFrameworkCore;
using FundooNotes.Models.Entities;
using FundooNotes.Repository.Data;
using FundooNotes.Repository.Interface;

namespace FundooNotes.Repository.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly AppDbContext _context;

        public ReminderRepository(AppDbContext context)
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
