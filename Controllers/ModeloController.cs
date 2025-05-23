using API_NET.Data;
using API_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ModeloController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelo>>> GetAll() =>
            await _context.Modelos.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetById(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            return modelo is null ? NotFound() : modelo;
        }

        [HttpPost]
        public async Task<ActionResult<Modelo>> Create(Modelo modelo)
        {
            _context.Modelos.Add(modelo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = modelo.Id }, modelo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Modelo modelo)
        {
            if (id != modelo.Id) return BadRequest();
            _context.Entry(modelo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo is null) return NotFound();
            _context.Modelos.Remove(modelo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}