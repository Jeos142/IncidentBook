using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IncidentBook.Models;
using IncidentBook.Models.DTOs;
using IncidentBook.Services.Interfaces;

namespace IncidentBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClosedIncidentsItemsController : ControllerBase
    {
        //private readonly IncidentContext _context;

        //public ClosedIncidentsItemsController(IncidentContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/ClosedIncidentsItems
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ClosedIncidentsItem>>> GetClosedIncidentsItems()
        //{
        //    return await _context.ClosedIncidentsItems
        //        .OrderBy(item => item.Resolution)
        //        .ToListAsync();
        //}

        //// GET: api/ClosedIncidentsItems/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ClosedIncidentsItem>> GetClosedIncidentsItem(int id)
        //{
        //    var closedIncidentsItem = await _context.ClosedIncidentsItems.FindAsync(id);

        //    if (closedIncidentsItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return closedIncidentsItem;
        //}

        //// PUT: api/ClosedIncidentsItems/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutClosedIncidentsItem(int id, ClosedIncidentsItem closedIncidentsItem)
        //{
        //    if (id != closedIncidentsItem.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(closedIncidentsItem).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClosedIncidentsItemExists(id))
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

        //// POST: api/ClosedIncidentsItems
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ClosedIncidentsItem>> PostClosedIncidentsItem(ClosedIncidentsItem closedIncidentsItem)
        //{
        //    _context.ClosedIncidentsItems.Add(closedIncidentsItem);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetClosedIncidentsItem), new { id = closedIncidentsItem.Id }, closedIncidentsItem);
        //}

        //// DELETE: api/ClosedIncidentsItems/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteClosedIncidentsItem(int id)
        //{
        //    var closedIncidentsItem = await _context.ClosedIncidentsItems.FindAsync(id);
        //    if (closedIncidentsItem == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.ClosedIncidentsItems.Remove(closedIncidentsItem);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ClosedIncidentsItemExists(int id)
        //{
        //    return _context.ClosedIncidentsItems.Any(e => e.Id == id);
        //}
        private readonly IResolutionService _service;

        public ClosedIncidentsItemsController(IResolutionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResolutionDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ResolutionDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
