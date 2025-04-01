using IncidentBook.Models;
using IncidentBook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IncidentBook.Repositories
{
    public class ResolutionRepository : IResolutionRepository
    {
        private readonly IncidentContext _context;

        public ResolutionRepository(IncidentContext context)
        {
            _context = context;
        }

        public async Task<List<ClosedIncidentsItem>> GetAllAsync()
        {
            return await _context.ClosedIncidentsItems.ToListAsync();
        }

        public async Task<ClosedIncidentsItem?> GetByIdAsync(int id)
        {
            return await _context.ClosedIncidentsItems.FindAsync(id);
        }

        public async Task AddAsync(ClosedIncidentsItem resolution)
        {
            await _context.ClosedIncidentsItems.AddAsync(resolution);
        }

        public void Update(ClosedIncidentsItem resolution)
        {
            _context.ClosedIncidentsItems.Update(resolution);
        }

        public void Remove(ClosedIncidentsItem resolution)
        {
            _context.ClosedIncidentsItems.Remove(resolution);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
