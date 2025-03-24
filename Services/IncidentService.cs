using IncidentBook.Models.DTOs;
using IncidentBook.Models;
using IncidentBook.Repositories.Interfaces;
using IncidentBook.Services.Interfaces;

namespace IncidentBook.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;

        public IncidentService(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<IncidentCreateResponseDto> CreateIncidentAsync(IncidentCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Description) || dto.ClientId == 0)
                throw new ArgumentException("Все обязательные поля должны быть заполнены.");

            var incident = new IncidentItem
            {
                DateTime = dto.DateTime,
                Description = dto.Description,
                ClientId = dto.ClientId,
                ClassificationId = dto.ClassificationId,
                IsComplete = dto.IsComplete,
                ResolutionId = dto.IsComplete ? dto.ResolutionId : null
            };

            await _incidentRepository.AddAsync(incident);
            await _incidentRepository.SaveChangesAsync();

            var fullIncident = await _incidentRepository.GetByIdWithRelationsAsync(incident.Id);
            if (fullIncident == null)
                throw new InvalidOperationException("Инцидент не найден после сохранения.");

            return new IncidentCreateResponseDto
            {
                Id = fullIncident.Id,
                DateTime = fullIncident.DateTime,
                Description = fullIncident.Description,
                ClientId = fullIncident.ClientId,
                ClientName = fullIncident.ClientItem?.Name ?? "Неизвестный клиент",
                Classification = fullIncident.Classification?.ClassificationName ?? "Неизвестная классификация",
                IsComplete = fullIncident.IsComplete,
                Resolution = fullIncident.Resolution?.Resolution,
                ResolutionId=fullIncident.ResolutionId,
                ClassificationId=fullIncident.ClassificationId,
            };
        }
        public async Task<List<IncidentDto>> GetAllIncidentsAsync()
        {
            var incidents = await _incidentRepository.GetAllWithRelationsAsync();

            return incidents.Select(i => new IncidentDto
            {
                Id = i.Id,
                DateTime = i.DateTime,
                Description = i.Description,
                IsComplete = i.IsComplete,
                ClientId = i.ClientId,
                Client = new ClientDto
                {
                    Id = i.ClientItem.Id,
                    Name = i.ClientItem.Name
                },
                ClassificationId = i.ClassificationId,
                Classification = new ClassificationDto
                {
                    Id = i.Classification.Id,
                    ClassificationName = i.Classification.ClassificationName
                },
                ResolutionId = i.ResolutionId,
                Resolution = i.Resolution == null ? null : new ResolutionDto
                {
                    Id = i.Resolution.Id,
                    Resolution = i.Resolution.Resolution
                }
            }).ToList();
        }

        public async Task<bool> UpdateIncidentAsync(long id, IncidentUpdateDto dto)
        {
            var incident = await _incidentRepository.GetByIdAsync(id);
            if (incident == null) return false;

            incident.DateTime = dto.DateTime;
            incident.Description = dto.Description;
            incident.ClientId = dto.ClientId;
            incident.ClassificationId = dto.ClassificationId;
            incident.IsComplete = dto.IsComplete;
            incident.ResolutionId = dto.IsComplete ? dto.ResolutionId : null;

            _incidentRepository.Update(incident);
            await _incidentRepository.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteIncidentAsync(long id)
        {
            var incident = await _incidentRepository.GetByIdAsync(id);
            if (incident == null) return false;

            _incidentRepository.Remove(incident);
            await _incidentRepository.SaveChangesAsync();
            return true;
        }

    }
}
