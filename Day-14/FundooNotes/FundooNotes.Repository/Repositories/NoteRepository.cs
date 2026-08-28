using Microsoft.EntityFrameworkCore;
using FundooNotes.Models;
using FundooNotes.Repository.Data;
using FundooNotes.Repository.Interface;

namespace FundooNotes.Repository.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;

        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<NotesEntity> CreateNoteAsync(NotesEntity note)
        {
            note.Created = DateTime.UtcNow;
            note.Edited = DateTime.UtcNow;
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<IEnumerable<NotesEntity>> GetAllNotesByUserIdAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && !n.Trash)
                .OrderByDescending(n => n.Edited)
                .ToListAsync();
        }

        public async Task<bool> DeleteNoteAsync(long noteId, int userId)
        {
            var note = await _context.Notes
                .FirstOrDefaultAsync(n => n.NoteId == noteId && n.UserId == userId);

            if (note == null)
                return false;

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
