using FundooNotes.Models;
using FundooNotes.Models.Entities;
using FundooNotes.Models.DTOs;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Interface;

namespace FundooNotes.Service.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<NotesEntity> CreateNoteAsync(CreateNoteDto noteDto, int userId)
        {
            var note = new NotesEntity
            {
                Title = noteDto.Title,
                Description = noteDto.Description,
                Reminder = noteDto.Reminder,
                Backgroundcolor = noteDto.Backgroundcolor,
                Image = noteDto.Image,
                Pin = noteDto.Pin,
                Archive = noteDto.Archive,
                Trash = false,
                UserId = userId
            };

            return await _noteRepository.CreateNoteAsync(note);
        }

        public async Task<IEnumerable<NotesEntity>> GetAllNotesAsync(int userId)
        {
            return await _noteRepository.GetAllNotesByUserIdAsync(userId);
        }

        public async Task<bool> DeleteNoteAsync(long noteId, int userId)
        {
            return await _noteRepository.DeleteNoteAsync(noteId, userId);
        }

        public async Task<bool> PinNoteAsync(long noteId, int userId)
        {
            return await _noteRepository.PinNoteAsync(noteId, userId);
        }

        public async Task<bool> ArchiveNoteAsync(long noteId, int userId)
        {
            return await _noteRepository.ArchiveNoteAsync(noteId, userId);
        }

        public async Task<bool> TrashNoteAsync(long noteId, int userId)
        {
            return await _noteRepository.TrashNoteAsync(noteId, userId);
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
