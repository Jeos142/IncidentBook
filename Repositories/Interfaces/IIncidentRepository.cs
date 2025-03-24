using IncidentBook.Models;

namespace IncidentBook.Repositories.Interfaces
{
    public interface IIncidentRepository
    {
        Task AddAsync(IncidentItem incident);
        Task<IncidentItem?> GetByIdWithRelationsAsync(long id);
        Task SaveChangesAsync();
        Task<List<IncidentItem>> GetAllWithRelationsAsync();
        Task<IncidentItem?> GetByIdAsync(long id);
        void Update(IncidentItem incident);
        void Remove(IncidentItem incident);
    }
}
