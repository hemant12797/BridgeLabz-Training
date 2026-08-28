using FundooNotes.Models;
using FundooNotes.Models.Entities;

namespace FundooNotes.Repository.Interface
{
    public interface INoteRepository
    {
        Task<NotesEntity> CreateNoteAsync(NotesEntity note);
        Task<IEnumerable<NotesEntity>> GetAllNotesByUserIdAsync(int userId);
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
