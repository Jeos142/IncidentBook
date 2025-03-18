using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IncidentBook.Models;

namespace IncidentBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentClassificationsController : ControllerBase
    {
        private readonly IncidentContext _context;

        public IncidentClassificationsController(IncidentContext context)
        {
            _context = context;
        }

        // GET: api/IncidentClassifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentClassification>>> GetIncidentClassifications()
        {
            return await _context.IncidentClassifications
                .OrderBy(item => item.ClassificationName)
                .ToListAsync();
        }

        // GET: api/IncidentClassifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentClassification>> GetIncidentClassification(int id)
        {
            var incidentClassification = await _context.IncidentClassifications.FindAsync(id);

            if (incidentClassification == null)
            {
                return NotFound();
            }

            return incidentClassification;
        }

        // PUT: api/IncidentClassifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentClassification(int id, IncidentClassification incidentClassification)
        {
            if (id != incidentClassification.Id)
            {
                return BadRequest();
            }

            _context.Entry(incidentClassification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentClassificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IncidentClassifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IncidentClassification>> PostIncidentClassification(IncidentClassification incidentClassification)
        {
            _context.IncidentClassifications.Add(incidentClassification);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIncidentClassification), new { id = incidentClassification.Id }, incidentClassification);
        }

        // DELETE: api/IncidentClassifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidentClassification(int id)
        {
            var incidentClassification = await _context.IncidentClassifications.FindAsync(id);
            if (incidentClassification == null)
            {
                return NotFound();
            }

            _context.IncidentClassifications.Remove(incidentClassification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidentClassificationExists(int id)
        {
            return _context.IncidentClassifications.Any(e => e.Id == id);
        }
    }
}
