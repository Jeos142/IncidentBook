using IncidentBook.Models.DTOs;
using IncidentBook.Models;
using IncidentBook.Repositories.Interfaces;
using IncidentBook.Services.Interfaces;

namespace IncidentBook.Services
{
    public class ResolutionService : IResolutionService
    {
        private readonly IResolutionRepository _repo;

        public ResolutionService(IResolutionRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ResolutionDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(r => new ResolutionDto
            {
                Id = r.Id,
                Resolution = r.Resolution
            }).ToList();
        }

        public async Task<ResolutionDto?> GetByIdAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            return item == null ? null : new ResolutionDto
            {
                Id = item.Id,
                Resolution = item.Resolution
            };
        }

        public async Task<ResolutionDto> CreateAsync(ResolutionDto dto)
        {
            var entity = new ClosedIncidentsItem { Resolution = dto.Resolution };
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
            return new ResolutionDto { Id = entity.Id, Resolution = entity.Resolution };
        }

        public async Task<bool> UpdateAsync(int id, ResolutionDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            entity.Resolution = dto.Resolution;
            _repo.Update(entity);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            _repo.Remove(entity);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
