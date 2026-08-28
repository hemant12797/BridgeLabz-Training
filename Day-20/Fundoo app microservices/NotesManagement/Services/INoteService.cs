using NotesManagement.Models;
using NotesManagement.Models.DTOs;

namespace NotesManagement.Services
{
    public interface INoteService
    {
        Task<NotesEntity> CreateNoteAsync(CreateNoteDto noteDto, int userId);
        Task<IEnumerable<NotesEntity>> GetRecentNotesAsync(int userId);
        Task<IEnumerable<NotesEntity>> GetAllNotesAsync(int userId);
        Task<bool> DeleteNoteAsync(long noteId, int userId);
        Task<bool> PinNoteAsync(long noteId, int userId);
        Task<bool> ArchiveNoteAsync(long noteId, int userId);
        Task<bool> TrashNoteAsync(long noteId, int userId);
        Task<IEnumerable<NotesEntity>> SearchNotesByTitleAsync(string title, int userId);
        Task<IEnumerable<NotesEntity>> GetPinnedNotesAsync(int userId);
        Task<IEnumerable<NotesEntity>> GetArchivedNotesAsync(int userId);
        Task<IEnumerable<NotesEntity>> GetTrashNotesAsync(int userId);
    }
}
