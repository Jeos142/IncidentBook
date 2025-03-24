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
    public class ClientItemsController : ControllerBase
    {
        //    private readonly IncidentContext _context;

        //    public ClientItemsController(IncidentContext context)
        //    {
        //        _context = context;
        //    }

        //    // GET: api/ClientItems
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<ClientItem>>> GetClients()
        //    {
        //        return await _context.ClientItems
        //            .OrderBy(item => item.Name)
        //            .ToListAsync();
        //    }

        //    // GET: api/ClientItems/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<ClientItem>> GetClientItem(int id)
        //    {
        //        var clientItem = await _context.ClientItems.FindAsync(id);

        //        if (clientItem == null)
        //        {
        //            return NotFound();
        //        }

        //        return clientItem;
        //    }

        //    // PUT: api/ClientItems/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutClientItem(int id, ClientItem clientItem)
        //    {
        //        if (id != clientItem.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(clientItem).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ClientItemExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/ClientItems
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<ClientItem>> PostClientItem(ClientItem clientItem)
        //    {
        //        clientItem.Incidents = null;
        //        _context.ClientItems.Add(clientItem);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction(nameof(GetClientItem), new { id = clientItem.Id }, clientItem);
        //    }

        //    // DELETE: api/ClientItems/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteClientItem(int id)
        //    {
        //        var clientItem = await _context.ClientItems.FindAsync(id);
        //        if (clientItem == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.ClientItems.Remove(clientItem);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool ClientItemExists(int id)
        //    {
        //        return _context.ClientItems.Any(e => e.Id == id);
        //    }

        private readonly IClientService _clientService;

        public ClientItemsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clientService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _clientService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientDto dto)
        {
            var created = await _clientService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClientDto dto)
        {
            var updated = await _clientService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _clientService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }

}
