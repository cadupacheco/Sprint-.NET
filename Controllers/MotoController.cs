using API_NET.Data;
using API_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MotoController(AppDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> GetAll() =>
            await _context.Motos.Include(m => m.Modelo).Include(m => m.Patio).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> GetById(int id)
        {
            var moto = await _context.Motos.Include(m => m.Modelo).Include(m => m.Patio).FirstOrDefaultAsync(m => m.Id == id);
            return moto is null ? NotFound() : moto;
        }

        [HttpPost]
        public async Task<ActionResult<Moto>> Create(Moto moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = moto.Id }, moto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Moto moto)
        {
            if (id != moto.Id) return BadRequest();
            _context.Entry(moto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto is null) return NotFound();
            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}