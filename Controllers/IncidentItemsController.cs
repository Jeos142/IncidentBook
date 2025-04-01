using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IncidentBook.Models;
using IncidentBook.Models.DTOs;
using Microsoft.CodeAnalysis;
using Humanizer;
using IncidentBook.Services.Interfaces;

namespace IncidentBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentItemsController : ControllerBase
    {
        //private readonly IncidentContext _context;

        //public IncidentItemsController(IncidentContext context)
        //{
        //    _context = context;
        //}

        private readonly IIncidentService _incidentService;

        public IncidentItemsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }



        // GET: api/IncidentItems
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<IncidentItem>>> GetTodoItems()
        //{
        //    return await _context.TodoItems
        //        .OrderBy(item => item.DateTime)             
        //        .ToListAsync();
        //}
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<IncidentDto>>> GetTodoItems()
        //{
        //    var incidents = await _context.TodoItems
        //        .Include(i => i.ClientItem)
        //        .Include(i => i.Classification)
        //        .Include(i => i.Resolution)
        //        .OrderBy(i => i.DateTime)
        //        .Select(i => new IncidentDto
        //        {
        //            Id = i.Id,
        //            DateTime = i.DateTime,
        //            Description = i.Description,
        //            IsComplete = i.IsComplete,
        //            ClientId = i.ClientId,
        //            Client = new ClientDto
        //            {
        //                Id = i.ClientItem.Id,
        //                Name = i.ClientItem.Name
        //            },
        //            ClassificationId = i.ClassificationId,
        //            Classification = new ClassificationDto
        //            {
        //                Id = i.Classification.Id,
        //                ClassificationName = i.Classification.ClassificationName
        //            },
        //            ResolutionId = i.ResolutionId,
        //            Resolution = i.Resolution == null ? null : new ResolutionDto
        //            {
        //                Id = i.Resolution.Id,
        //                Resolution = i.Resolution.Resolution
        //            }
        //        })
        //        .ToListAsync();

        //    return Ok(incidents);
        //}


        // GET: api/IncidentItems/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IncidentItem>> GetIncidentItem(long id)
        //{
        //    var incidentItem = await _context.TodoItems.FindAsync(id);

        //    if (incidentItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return incidentItem;
        //}

        // PUT: api/IncidentItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutIncidentItem(long id, IncidentItem incidentItem)
        //{
        //    if (id != incidentItem.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(incidentItem).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!IncidentItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateIncidentItem(long id, IncidentUpdateDto dto)
        //{
        //    if (dto == null || string.IsNullOrWhiteSpace(dto.Description) || dto.ClientId <= 0 || dto.ClassificationId <= 0)
        //    {
        //        return BadRequest("Заполните все обязательные поля.");
        //    }

        //    var incident = await _context.TodoItems.FindAsync(id);
        //    if (incident == null)
        //    {
        //        return NotFound("Инцидент не найден.");
        //    }

        //    // Обновляем только измененные поля
        //    incident.DateTime = dto.DateTime;
        //    incident.Description = dto.Description;
        //    incident.ClientId = dto.ClientId;
        //    incident.ClassificationId = dto.ClassificationId;
        //    incident.IsComplete = dto.IsComplete;
        //    incident.ResolutionId = dto.IsComplete ? dto.ResolutionId : null;

        //    _context.TodoItems.Update(incident);
        //    await _context.SaveChangesAsync();

        //    return NoContent(); // 204 No Content - успешное обновление без возврата объекта
        //}


        // POST: api/IncidentItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<IncidentItem>> PostIncidentItem(IncidentCreateDto dto)
        //{
        //    if (dto == null || string.IsNullOrWhiteSpace(dto.Description) || dto.ClientId <= 0 || dto.ClassificationId <= 0)
        //    {
        //        return BadRequest("Заполните все обязательные поля.");
        //    }

        //    var incident = new IncidentItem
        //    {
        //        DateTime = dto.DateTime,
        //        Description = dto.Description,
        //        ClientId = dto.ClientId,
        //        ClassificationId = dto.ClassificationId,
        //        IsComplete = dto.IsComplete,
        //        ResolutionId = dto.IsComplete ? dto.ResolutionId : null
        //    };

        //    _context.TodoItems.Add(incident);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetIncidentItem), new { id = incident.Id }, incident);
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateIncidentWithDetails([FromBody] IncidentCreateDto request)
        //{
        //    if (request == null || string.IsNullOrWhiteSpace(request.Description) || request.ClientId == 0)
        //    {
        //        return BadRequest("Все обязательные поля должны быть заполнены.");
        //    }

        //    // Создаем новый инцидент
        //    var incident = new IncidentItem
        //    {
        //        DateTime = request.DateTime,
        //        Description = request.Description,
        //        ClientId = request.ClientId,
        //        ClassificationId = request.ClassificationId,
        //        IsComplete = request.IsComplete,
        //        ResolutionId = request.IsComplete ? request.ResolutionId : null
        //    };

        //    _context.TodoItems.Add(incident);
        //    await _context.SaveChangesAsync();



        //    // Возвращаем готовый объект, чтобы на клиенте не нужно было получать имя клиента, классификацию и резолюцию
        //    var result = await _context.TodoItems
        //        .Where(i => i.Id == incident.Id)
        //        .Select(i => new IncidentCreateResponseDto
        //        {
        //            Id = i.Id,
        //            DateTime = i.DateTime,
        //            Description = i.Description,
        //            ClientId = i.ClientId,
        //            ClientName = i.ClientItem.Name,
        //            Classification = i.Classification.ClassificationName,
        //            IsComplete = i.IsComplete,
        //            Resolution = i.Resolution != null ? i.Resolution.Resolution : null
        //        })
        //        .FirstOrDefaultAsync();

        //    return Ok(result);
        //}


        [HttpPost]
        public async Task<IActionResult> CreateIncident([FromBody] IncidentCreateDto dto)
        {
            try
            {
                var result = await _incidentService.CreateIncidentAsync(dto);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ошибка сервера: " + ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var incidents = await _incidentService.GetAllIncidentsAsync();
            return Ok(incidents);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncident(long id, IncidentUpdateDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Description) || dto.ClientId <= 0 || dto.ClassificationId <= 0)
                return BadRequest("Заполните все обязательные поля.");

            var updated = await _incidentService.UpdateIncidentAsync(id, dto);
            if (!updated) return NotFound("Инцидент не найден.");

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(long id)
        {
            var deleted = await _incidentService.DeleteIncidentAsync(id);
            if (!deleted) return NotFound("Инцидент не найден.");

            return NoContent(); // 204 - всё удалено, тело не возвращается
        }


        // DELETE: api/IncidentItems/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteIncidentItem(long id)
        //{
        //    var incidentItem = await _context.TodoItems.FindAsync(id);
        //    if (incidentItem == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TodoItems.Remove(incidentItem);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool IncidentItemExists(long id)
        //{
        //    return _context.TodoItems.Any(e => e.Id == id);
        //}


    }
}
