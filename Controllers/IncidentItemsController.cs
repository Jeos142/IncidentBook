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
    public class IncidentItemsController : ControllerBase
    {
        private readonly IncidentContext _context;

        public IncidentItemsController(IncidentContext context)
        {
            _context = context;
        }

        // GET: api/IncidentItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentItem>>> GetTodoItems()
        {
            return await _context.TodoItems
                .OrderBy(item => item.DateTime)
                .ToListAsync();
        }

        // GET: api/IncidentItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentItem>> GetIncidentItem(long id)
        {
            var incidentItem = await _context.TodoItems.FindAsync(id);

            if (incidentItem == null)
            {
                return NotFound();
            }

            return incidentItem;
        }

        // PUT: api/IncidentItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentItem(long id, IncidentItem incidentItem)
        {
            if (id != incidentItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(incidentItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentItemExists(id))
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

        // POST: api/IncidentItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IncidentItem>> PostIncidentItem(IncidentItem incidentItem)
        {
            _context.TodoItems.Add(incidentItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIncidentItem), new { id = incidentItem.Id }, incidentItem);

        }

        // DELETE: api/IncidentItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidentItem(long id)
        {
            var incidentItem = await _context.TodoItems.FindAsync(id);
            if (incidentItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(incidentItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidentItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
