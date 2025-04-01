using IncidentBook.Models;
using IncidentBook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IncidentBook.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly IncidentContext _context;

        public IncidentRepository(IncidentContext context)
        {
            _context = context;
        }

        public async Task AddAsync(IncidentItem incident)
        {
            await _context.TodoItems.AddAsync(incident);
        }

        public async Task<IncidentItem?> GetByIdWithRelationsAsync(long id)
        {
            return await _context.TodoItems
                .Include(i => i.ClientItem)
                .Include(i => i.Classification)
                .Include(i => i.Resolution)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<List<IncidentItem>> GetAllWithRelationsAsync()
        {
            return await _context.TodoItems
                .Include(i => i.ClientItem)
                .Include(i => i.Classification)
                .Include(i => i.Resolution)
                .OrderBy(i => i.DateTime)
                .ToListAsync();
        }

        public async Task<IncidentItem?> GetByIdAsync(long id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public void Update(IncidentItem incident)
        {
            _context.TodoItems.Update(incident);
        }
        public void Remove(IncidentItem incident)
        {
            _context.TodoItems.Remove(incident);
        }

    }
}
