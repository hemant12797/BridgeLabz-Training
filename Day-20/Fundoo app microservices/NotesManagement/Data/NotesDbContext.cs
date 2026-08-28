using Microsoft.EntityFrameworkCore;
using NotesManagement.Models;

namespace NotesManagement.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {
        }

        public DbSet<NotesEntity> Notes { get; set; }
    }
}
