using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sprint1.Dtos;
using Sprint1.Entities;
using Sprint1.Repositories;

namespace Sprint1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatioController : ControllerBase
    {
        private readonly IPatioRepository _repo;

        public PatioController(IPatioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatioReadDto>>> GetPatios([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var patios = await _repo.GetPatiosPagedAsync(pageNumber, pageSize);
            var total = await _repo.GetCountAsync();
            Response.Headers.Add("X-Total-Count", total.ToString());

            var dtos = patios.Select(p => new PatioReadDto { Id = p.Id, Nome = p.Nome, Localizacao = p.Localizacao }).ToList();
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetPatioById")]
        public async Task<ActionResult<PatioReadDto>> GetPatioById(int id)
        {
            var patio = await _repo.GetPatioByIdAsync(id);
            if (patio == null) return NotFound();

            var dto = new PatioReadDto { Id = patio.Id, Nome = patio.Nome, Localizacao = patio.Localizacao };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<PatioReadDto>> CreatePatio(PatioCreateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var patio = new Patio { Nome = createDto.Nome, Localizacao = createDto.Localizacao };
            await _repo.AddPatioAsync(patio);
            await _repo.SaveChangesAsync();

            var dto = new PatioReadDto { Id = patio.Id, Nome = patio.Nome, Localizacao = patio.Localizacao };
            return CreatedAtRoute("GetPatioById", new { id = patio.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatio(int id, PatioCreateDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var patio = await _repo.GetPatioByIdAsync(id);
            if (patio == null) return NotFound();

            patio.Nome = updateDto.Nome;
            patio.Localizacao = updateDto.Localizacao;

            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatio(int id)
        {
            var patio = await _repo.GetPatioByIdAsync(id);
            if (patio == null) return NotFound();

            _repo.DeletePatio(patio);
            await _repo.SaveChangesAsync();
            return NoContent();
        }
    }
}
