using Microsoft.EntityFrameworkCore;
using FundooNotes.Models;
using FundooNotes.Models.Entities;
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

        public async Task<bool> PinNoteAsync(long noteId, int userId)
        {
            var note = await _context.Notes
                .FirstOrDefaultAsync(n => n.NoteId == noteId && n.UserId == userId);

            if (note == null)
                return false;

            note.Pin = !note.Pin;
            if (note.Pin)
            {
                note.Archive = false;
            }
            note.Edited = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ArchiveNoteAsync(long noteId, int userId)
        {
            var note = await _context.Notes
                .FirstOrDefaultAsync(n => n.NoteId == noteId && n.UserId == userId);

            if (note == null)
                return false;

            note.Archive = !note.Archive;
            if (note.Archive)
            {
                note.Pin = false;
            }
            note.Edited = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TrashNoteAsync(long noteId, int userId)
        {
            var note = await _context.Notes
                .FirstOrDefaultAsync(n => n.NoteId == noteId && n.UserId == userId);

            if (note == null)
                return false;

            note.Trash = !note.Trash;
            note.Edited = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<NotesEntity>> SearchNotesByTitleAsync(string title, int userId)
        {
            if (string.IsNullOrWhiteSpace(title))
                return await GetAllNotesByUserIdAsync(userId);

            return await _context.Notes
                .Where(n => n.UserId == userId && EF.Functions.Like(n.Title, $"%{title}%"))
                .ToListAsync();
        }

        public async Task<IEnumerable<NotesEntity>> GetPinnedNotesAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && n.Pin && !n.Trash)
                .ToListAsync();
        }

        public async Task<IEnumerable<NotesEntity>> GetArchivedNotesAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && n.Archive && !n.Trash)
                .OrderByDescending(n => n.Edited)
                .ToListAsync();
        }

        public async Task<IEnumerable<NotesEntity>> GetTrashNotesAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId && n.Trash)
                .OrderByDescending(n => n.Edited)
                .ToListAsync();
        }
    }
}
