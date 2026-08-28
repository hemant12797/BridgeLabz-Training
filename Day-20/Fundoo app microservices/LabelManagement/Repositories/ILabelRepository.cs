using LabelManagement.Models;

namespace LabelManagement.Repositories
{
    public interface ILabelRepository
    {
        Task<LabelEntity> AddLabelAsync(LabelEntity label);
        Task<LabelEntity?> GetLabelByIdAsync(int labelId, int userId);
        Task<LabelEntity?> EditLabelAsync(int labelId, string labelName, int userId);
        Task<IEnumerable<LabelEntity>> GetAllLabelsAsync(int userId);
        Task<bool> DeleteLabelAsync(int labelId, int userId);
    }
}
