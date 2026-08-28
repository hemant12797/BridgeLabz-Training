using Microsoft.EntityFrameworkCore;
using LabelManagement.Models;

namespace LabelManagement.Data
{
    public class LabelDbContext : DbContext
    {
        public LabelDbContext(DbContextOptions<LabelDbContext> options) : base(options)
        {
        }

        // LabelManagement owns only Labels and Reminders in FundooLabelDb
        public DbSet<LabelEntity> Labels { get; set; }
        public DbSet<ReminderModel> Reminders { get; set; }
    }
}
