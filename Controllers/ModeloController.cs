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
    public class ModeloController : ControllerBase
    {
        private readonly IModeloRepository _repo;

        public ModeloController(IModeloRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloReadDto>>> GetModelos([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var modelos = await _repo.GetModelosPagedAsync(pageNumber, pageSize);
            var total = await _repo.GetCountAsync();
            Response.Headers.Add("X-Total-Count", total.ToString());

            var dtos = modelos.Select(m => new ModeloReadDto
            {
                Id = m.Id,
                Nome = m.Nome,
                Fabricante = m.Fabricante
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetModeloById")]
        public async Task<ActionResult<ModeloReadDto>> GetModeloById(int id)
        {
            var modelo = await _repo.GetModeloByIdAsync(id);
            if (modelo == null) return NotFound();

            var dto = new ModeloReadDto { Id = modelo.Id, Nome = modelo.Nome, Fabricante = modelo.Fabricante };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ModeloReadDto>> CreateModelo(ModeloCreateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var modelo = new Modelo { Nome = createDto.Nome, Fabricante = createDto.Fabricante };
            await _repo.AddModeloAsync(modelo);
            await _repo.SaveChangesAsync();

            var dto = new ModeloReadDto { Id = modelo.Id, Nome = modelo.Nome, Fabricante = modelo.Fabricante };
            return CreatedAtRoute("GetModeloById", new { id = modelo.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModelo(int id, ModeloCreateDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var modelo = await _repo.GetModeloByIdAsync(id);
            if (modelo == null) return NotFound();

            modelo.Nome = updateDto.Nome;
            modelo.Fabricante = updateDto.Fabricante;

            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelo(int id)
        {
            var modelo = await _repo.GetModeloByIdAsync(id);
            if (modelo == null) return NotFound();

            _repo.DeleteModelo(modelo);
            await _repo.SaveChangesAsync();
            return NoContent();
        }
    }
}
