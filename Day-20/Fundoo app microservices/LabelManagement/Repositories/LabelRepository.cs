using Microsoft.EntityFrameworkCore;
using LabelManagement.Data;
using LabelManagement.Models;

namespace LabelManagement.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly LabelDbContext _context;

        public LabelRepository(LabelDbContext context)
        {
            _context = context;
        }

        public async Task<LabelEntity> AddLabelAsync(LabelEntity label)
        {
            await _context.Labels.AddAsync(label);
            await _context.SaveChangesAsync();
            return label;
        }

        public async Task<LabelEntity?> GetLabelByIdAsync(int labelId, int userId)
        {
            return await _context.Labels
                .FirstOrDefaultAsync(l => l.LabelId == labelId && l.UserId == userId);
        }

        public async Task<LabelEntity?> EditLabelAsync(int labelId, string labelName, int userId)
        {
            var label = await _context.Labels
                .FirstOrDefaultAsync(l => l.LabelId == labelId && l.UserId == userId);

            if (label == null)
                return null;

            label.LabelName = labelName;
            await _context.SaveChangesAsync();
            return label;
        }

        public async Task<IEnumerable<LabelEntity>> GetAllLabelsAsync(int userId)
        {
            return await _context.Labels
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> DeleteLabelAsync(int labelId, int userId)
        {
            var label = await _context.Labels
                .FirstOrDefaultAsync(l => l.LabelId == labelId && l.UserId == userId);

            if (label == null)
                return false;

            _context.Labels.Remove(label);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
