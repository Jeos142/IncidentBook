using IncidentBook.Models.DTOs;

namespace IncidentBook.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAllAsync();
        Task<ClientDto?> GetByIdAsync(int id);
        Task<ClientDto> CreateAsync(ClientDto dto);
        Task<bool> UpdateAsync(int id, ClientDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
