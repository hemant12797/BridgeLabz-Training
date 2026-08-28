using LabelManagement.HttpClients;
using LabelManagement.Models;
using LabelManagement.Models.DTOs;
using LabelManagement.Repositories;

namespace LabelManagement.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IUserServiceClient _userClient;
        private readonly INoteServiceClient _noteClient;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReminderService(
            IReminderRepository reminderRepository,
            IUserServiceClient userClient,
            INoteServiceClient noteClient,
            IRabbitMQService rabbitMQService,
            IHttpContextAccessor httpContextAccessor)
        {
            _reminderRepository = reminderRepository;
            _userClient = userClient;
            _noteClient = noteClient;
            _rabbitMQService = rabbitMQService;
            _httpContextAccessor = httpContextAccessor;
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

            // Extract JWT from the current HTTP request to forward to sibling services
            var jwtToken = ExtractJwtToken();

            // Call UserManagement service to get user email
            var userEmail = await _userClient.GetUserEmailAsync(userId, jwtToken);

            // Call NotesManagement service to get note title
            var noteTitle = await _noteClient.GetNoteTitleAsync(dto.NoteId, userId, jwtToken);

            var message = new ReminderMessage
            {
                ReminderId = createdReminder.ReminderId,
                NoteId = createdReminder.NoteId,
                UserId = userId,
                Email = userEmail ?? string.Empty,
                ReminderTime = createdReminder.ReminderTime,
                NoteTitle = noteTitle ?? "Note Reminder"
            };

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

        // Extracts the raw JWT from the Authorization header of the current request
        private string ExtractJwtToken()
        {
            var authHeader = _httpContextAccessor.HttpContext?
                .Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
                return string.Empty;

            return authHeader["Bearer ".Length..];
        }
    }
}
