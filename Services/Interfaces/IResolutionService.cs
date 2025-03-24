using IncidentBook.Models.DTOs;

namespace IncidentBook.Services.Interfaces
{
    public interface IResolutionService
    {
        Task<List<ResolutionDto>> GetAllAsync();
        Task<ResolutionDto?> GetByIdAsync(int id);
        Task<ResolutionDto> CreateAsync(ResolutionDto dto);
        Task<bool> UpdateAsync(int id, ResolutionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
