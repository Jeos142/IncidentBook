using IncidentBook.Models;

namespace IncidentBook.Repositories.Interfaces
{
    public interface IResolutionRepository
    {
        Task<List<ClosedIncidentsItem>> GetAllAsync();
        Task<ClosedIncidentsItem?> GetByIdAsync(int id);
        Task AddAsync(ClosedIncidentsItem resolution);
        void Update(ClosedIncidentsItem resolution);
        void Remove(ClosedIncidentsItem resolution);
        Task SaveChangesAsync();
    }
}
