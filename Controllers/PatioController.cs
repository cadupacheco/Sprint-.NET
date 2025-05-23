using API_NET.Data;
using API_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PatioController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patio>>> GetAll() =>
            await _context.Patios.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Patio>> GetById(int id)
        {
            var patio = await _context.Patios.FindAsync(id);
            return patio is null ? NotFound() : patio;
        }

        [HttpPost]
        public async Task<ActionResult<Patio>> Create(Patio patio)
        {
            _context.Patios.Add(patio);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = patio.Id }, patio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Patio patio)
        {
            if (id != patio.Id) return BadRequest();
            _context.Entry(patio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio is null) return NotFound();
            _context.Patios.Remove(patio);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}