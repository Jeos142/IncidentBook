using IncidentBook.Models;

namespace IncidentBook.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientItem>> GetAllAsync();
        Task<ClientItem?> GetByIdAsync(int id);
        Task AddAsync(ClientItem client);
        void Update(ClientItem client);
        void Remove(ClientItem client);
        Task SaveChangesAsync();
    }
}
