using FundooNotes.Models;

namespace FundooNotes.Repository.Interface
{
    public interface INoteRepository
    {
        Task<NotesEntity> CreateNoteAsync(NotesEntity note);
        Task<IEnumerable<NotesEntity>> GetAllNotesByUserIdAsync(int userId);
        Task<bool> DeleteNoteAsync(long noteId, int userId);
    }
}
