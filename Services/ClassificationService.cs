using IncidentBook.Models.DTOs;
using IncidentBook.Models;
using IncidentBook.Repositories.Interfaces;
using IncidentBook.Services.Interfaces;

namespace IncidentBook.Services
{
    public class ClassificationService : IClassificationService
    {
        private readonly IClassificationRepository _repo;

        public ClassificationService(IClassificationRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ClassificationDto>> GetAllAsync()
        {
            var classifications = await _repo.GetAllAsync();
            return classifications.Select(c => new ClassificationDto
            {
                Id = c.Id,
                ClassificationName = c.ClassificationName
            }).ToList();
        }

        public async Task<ClassificationDto?> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            return c == null ? null : new ClassificationDto { Id = c.Id, ClassificationName = c.ClassificationName };
        }

        public async Task<ClassificationDto> CreateAsync(ClassificationDto dto)
        {
            var entity = new IncidentClassification { ClassificationName = dto.ClassificationName };
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
            return new ClassificationDto { Id = entity.Id, ClassificationName = entity.ClassificationName };
        }

        public async Task<bool> UpdateAsync(int id, ClassificationDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            entity.ClassificationName = dto.ClassificationName;
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
