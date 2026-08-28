using FundooNotes.Models.Entities;
using FundooNotes.Models.DTOs;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Interface;

namespace FundooNotes.Service.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService? _cache;

        public NoteService(INoteRepository noteRepository, ICacheService? cache = null)
        {
            _noteRepository = noteRepository;
            _cache = cache;
        }

        // Helper to generate a unique key for each user
        private static string CacheKey(int userId) => $"notes:recent:{userId}";

        public async Task<NotesEntity> CreateNoteAsync(CreateNoteDto noteDto, int userId)
        {
            var note = new NotesEntity
            {
                Title = noteDto.Title,
                Description = noteDto.Description,
                Backgroundcolor = noteDto.Backgroundcolor,
                Image = noteDto.Image,
                Pin = noteDto.Pin,
                Archive = noteDto.Archive,
                Trash = false,
                UserId = userId
            };

            var created = await _noteRepository.CreateNoteAsync(note);

            // Invalidate cache so next fetch gets fresh data
            if (_cache != null) await _cache.RemoveAsync(CacheKey(userId));

            return created;
        }

        // Returns last 5 recently edited notes - checks cache first
        public async Task<IEnumerable<NotesEntity>> GetRecentNotesAsync(int userId)
        {
            if (_cache != null)
            {
                var cached = await _cache.GetAsync<List<NotesEntity>>(CacheKey(userId));
                if (cached != null) return cached;
            }

            var allNotes = await _noteRepository.GetAllNotesByUserIdAsync(userId);
            var recent = allNotes.OrderByDescending(n => n.Edited).Take(5).ToList();

            if (_cache != null)
                await _cache.SetAsync(CacheKey(userId), recent, TimeSpan.FromMinutes(5));

            return recent;
        }

        public async Task<IEnumerable<NotesEntity>> GetAllNotesAsync(int userId)
        {
            return await _noteRepository.GetAllNotesByUserIdAsync(userId);
        }

        public async Task<bool> DeleteNoteAsync(long noteId, int userId)
        {
            var result = await _noteRepository.DeleteNoteAsync(noteId, userId);
            if (result && _cache != null) await _cache.RemoveAsync(CacheKey(userId));
            return result;
        }

        public async Task<bool> PinNoteAsync(long noteId, int userId)
        {
            var result = await _noteRepository.PinNoteAsync(noteId, userId);
            if (result && _cache != null) await _cache.RemoveAsync(CacheKey(userId));
            return result;
        }

        public async Task<bool> ArchiveNoteAsync(long noteId, int userId)
        {
            var result = await _noteRepository.ArchiveNoteAsync(noteId, userId);
            if (result && _cache != null) await _cache.RemoveAsync(CacheKey(userId));
            return result;
        }

        public async Task<bool> TrashNoteAsync(long noteId, int userId)
        {
            var result = await _noteRepository.TrashNoteAsync(noteId, userId);
            if (result && _cache != null) await _cache.RemoveAsync(CacheKey(userId));
            return result;
        }

        public async Task<IEnumerable<NotesEntity>> SearchNotesByTitleAsync(string title, int userId)
        {
            return await _noteRepository.SearchNotesByTitleAsync(title, userId);
        }

        public async Task<IEnumerable<NotesEntity>> GetPinnedNotesAsync(int userId)
        {
            return await _noteRepository.GetPinnedNotesAsync(userId);
        }

        public async Task<IEnumerable<NotesEntity>> GetArchivedNotesAsync(int userId)
        {
            return await _noteRepository.GetArchivedNotesAsync(userId);
        }

        public async Task<IEnumerable<NotesEntity>> GetTrashNotesAsync(int userId)
        {
            return await _noteRepository.GetTrashNotesAsync(userId);
        }
    }
}
