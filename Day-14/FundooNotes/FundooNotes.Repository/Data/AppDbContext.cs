using Microsoft.EntityFrameworkCore;
using FundooNotes.Models;

namespace FundooNotes.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<NotesEntity> Notes { get; set; }
    }
}
