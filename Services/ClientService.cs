using IncidentBook.Models.DTOs;
using IncidentBook.Models;
using IncidentBook.Repositories.Interfaces;
using IncidentBook.Services.Interfaces;

namespace IncidentBook.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClientDto>> GetAllAsync()
        {
            var clients = await _repository.GetAllAsync();
            return clients.Select(c => new ClientDto { Id = c.Id, Name = c.Name }).ToList();
        }

        public async Task<ClientDto?> GetByIdAsync(int id)
        {
            var client = await _repository.GetByIdAsync(id);
            return client == null ? null : new ClientDto { Id = client.Id, Name = client.Name };
        }

        public async Task<ClientDto> CreateAsync(ClientDto dto)
        {
            var client = new ClientItem { Name = dto.Name };
            await _repository.AddAsync(client);
            await _repository.SaveChangesAsync();
            return new ClientDto { Id = client.Id, Name = client.Name };
        }

        public async Task<bool> UpdateAsync(int id, ClientDto dto)
        {
            var client = await _repository.GetByIdAsync(id);
            if (client == null) return false;

            client.Name = dto.Name;
            _repository.Update(client);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = await _repository.GetByIdAsync(id);
            if (client == null) return false;

            _repository.Remove(client);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
