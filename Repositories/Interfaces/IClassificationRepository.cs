using IncidentBook.Models;

namespace IncidentBook.Repositories.Interfaces
{
    public interface IClassificationRepository
    {
        Task<List<IncidentClassification>> GetAllAsync();
        Task<IncidentClassification?> GetByIdAsync(int id);
        Task AddAsync(IncidentClassification classification);
        void Update(IncidentClassification classification);
        void Remove(IncidentClassification classification);
        Task SaveChangesAsync();
    }
}
