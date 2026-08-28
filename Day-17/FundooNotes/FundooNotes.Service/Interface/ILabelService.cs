using FundooNotes.Models.DTOs;
using FundooNotes.Models.Entities;

namespace FundooNotes.Service.Interface
{
    public interface ILabelService
    {
        Task<LabelEntity> AddLabelAsync(CreateLabelDto dto, int userId);
        Task<LabelEntity?> GetLabelByIdAsync(int labelId, int userId);
        Task<LabelEntity?> EditLabelAsync(int labelId, UpdateLabelDto dto, int userId);
        Task<IEnumerable<LabelEntity>> GetAllLabelsAsync(int userId);
        Task<bool> DeleteLabelAsync(int labelId, int userId);
    }
}
