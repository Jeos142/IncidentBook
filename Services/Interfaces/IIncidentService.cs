using IncidentBook.Models.DTOs;

namespace IncidentBook.Services.Interfaces
{
    public interface IIncidentService
    {
        Task<IncidentCreateResponseDto> CreateIncidentAsync(IncidentCreateDto dto);
        Task<List<IncidentDto>> GetAllIncidentsAsync();
        Task<bool> UpdateIncidentAsync(long id, IncidentUpdateDto dto);
        Task<bool> DeleteIncidentAsync(long id);

    }
}
