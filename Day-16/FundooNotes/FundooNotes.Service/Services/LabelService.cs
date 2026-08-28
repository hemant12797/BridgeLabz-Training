using FundooNotes.Models.DTOs;
using FundooNotes.Models.Entities;
using FundooNotes.Repository.Interface;
using FundooNotes.Service.Interface;

namespace FundooNotes.Service.Services
{
    public class LabelService : ILabelService
    {
        private readonly ILabelRepository _labelRepository;

        public LabelService(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public async Task<LabelEntity> AddLabelAsync(CreateLabelDto dto, int userId)
        {
            var label = new LabelEntity
            {
                LabelName = dto.LabelName,
                NoteId = dto.NoteId,
                UserId = userId
            };

            return await _labelRepository.AddLabelAsync(label);
        }

        public async Task<LabelEntity?> GetLabelByIdAsync(int labelId, int userId)
        {
            return await _labelRepository.GetLabelByIdAsync(labelId, userId);
        }

        public async Task<LabelEntity?> EditLabelAsync(int labelId, UpdateLabelDto dto, int userId)
        {
            return await _labelRepository.EditLabelAsync(labelId, dto.LabelName, userId);
        }

        public async Task<IEnumerable<LabelEntity>> GetAllLabelsAsync(int userId)
        {
            return await _labelRepository.GetAllLabelsAsync(userId);
        }

        public async Task<bool> DeleteLabelAsync(int labelId, int userId)
        {
            return await _labelRepository.DeleteLabelAsync(labelId, userId);
        }
    }
}
