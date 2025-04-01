using IncidentBook.Models;
using IncidentBook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IncidentBook.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IncidentContext _context;

        public ClientRepository(IncidentContext context)
        {
            _context = context;
        }

        public async Task<List<ClientItem>> GetAllAsync()
        {
            return await _context.ClientItems.ToListAsync();
        }

        public async Task<ClientItem?> GetByIdAsync(int id)
        {
            return await _context.ClientItems.FindAsync(id);
        }

        public async Task AddAsync(ClientItem client)
        {
            await _context.ClientItems.AddAsync(client);
        }

        public void Update(ClientItem client)
        {
            _context.ClientItems.Update(client);
        }

        public void Remove(ClientItem client)
        {
            _context.ClientItems.Remove(client);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
