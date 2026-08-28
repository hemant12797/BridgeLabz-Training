using FundooNotes.Models.Entities;
using FundooNotes.Models.DTOs;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Interface;

namespace FundooNotes.Service.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IUserRepository _userRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IRabbitMQService _rabbitMQService;

        public ReminderService(
            IReminderRepository reminderRepository,
            IUserRepository userRepository,
            INoteRepository noteRepository,
            IRabbitMQService rabbitMQService)
        {
            _reminderRepository = reminderRepository;
            _userRepository = userRepository;
            _noteRepository = noteRepository;
            _rabbitMQService = rabbitMQService;
        }

        public async Task<ReminderModel> CreateReminderAsync(CreateReminderDto dto, int userId)
        {
            var reminder = new ReminderModel
            {
                NoteId = dto.NoteId,
                ReminderTime = dto.ReminderTime,
                UserId = userId
            };

            var createdReminder = await _reminderRepository.CreateReminderAsync(reminder);

            // Fetch user and note details to publish payload to RabbitMQ
            var user = await _userRepository.GetByIdAsync(userId);
            var notes = await _noteRepository.GetAllNotesByUserIdAsync(userId);
            var note = notes.FirstOrDefault(n => n.NoteId == dto.NoteId);

            var message = new ReminderMessage
            {
                ReminderId = createdReminder.ReminderId,
                NoteId = createdReminder.NoteId,
                UserId = userId,
                Email = user?.Email ?? string.Empty,
                ReminderTime = createdReminder.ReminderTime,
                NoteTitle = note?.Title ?? "Note Reminder"
            };

            // Publish to RabbitMQ queue for processing notification
            await _rabbitMQService.PublishReminderAsync(message);

            return createdReminder;
        }

        public async Task<ReminderModel?> GetReminderByIdAsync(int reminderId, int userId)
        {
            return await _reminderRepository.GetReminderByIdAsync(reminderId, userId);
        }

        public async Task<IEnumerable<ReminderModel>> GetAllRemindersAsync(int userId)
        {
            return await _reminderRepository.GetAllRemindersAsync(userId);
        }

        public async Task<bool> DeleteReminderAsync(int reminderId, int userId)
        {
            return await _reminderRepository.DeleteReminderAsync(reminderId, userId);
        }
    }
}
