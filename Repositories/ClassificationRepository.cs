using IncidentBook.Models;
using IncidentBook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IncidentBook.Repositories
{
    public class ClassificationRepository : IClassificationRepository
    {
        private readonly IncidentContext _context;

        public ClassificationRepository(IncidentContext context)
        {
            _context = context;
        }

        public async Task<List<IncidentClassification>> GetAllAsync()
        {
            return await _context.IncidentClassifications.ToListAsync();
        }

        public async Task<IncidentClassification?> GetByIdAsync(int id)
        {
            return await _context.IncidentClassifications.FindAsync(id);
        }

        public async Task AddAsync(IncidentClassification classification)
        {
            await _context.IncidentClassifications.AddAsync(classification);
        }

        public void Update(IncidentClassification classification)
        {
            _context.IncidentClassifications.Update(classification);
        }

        public void Remove(IncidentClassification classification)
        {
            _context.IncidentClassifications.Remove(classification);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
