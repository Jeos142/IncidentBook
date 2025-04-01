using IncidentBook.Models.DTOs;

namespace IncidentBook.Services.Interfaces
{
    public interface IClassificationService
    {
        Task<List<ClassificationDto>> GetAllAsync();
        Task<ClassificationDto?> GetByIdAsync(int id);
        Task<ClassificationDto> CreateAsync(ClassificationDto dto);
        Task<bool> UpdateAsync(int id, ClassificationDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
