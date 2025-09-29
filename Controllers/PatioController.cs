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

        /// <summary>
        /// Lista todos os pátios com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Itens por página (padrão: 10)</param>
        /// <returns>Lista paginada de pátios</returns>
        /// <response code="200">Lista de pátios retornada com sucesso</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PatioReadDto>), 200)]
        public async Task<ActionResult<IEnumerable<PatioReadDto>>> GetPatios([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var patios = await _repo.GetPatiosPagedAsync(pageNumber, pageSize);
            var total = await _repo.GetCountAsync();
            Response.Headers["X-Total-Count"] = total.ToString();

            var dtos = patios.Select(p => new PatioReadDto { Id = p.Id, Nome = p.Nome, Localizacao = p.Localizacao }).ToList();
            return Ok(dtos);
        }

        /// <summary>
        /// Busca um pátio específico por ID
        /// </summary>
        /// <param name="id">ID do pátio</param>
        /// <returns>Dados do pátio solicitado</returns>
        /// <response code="200">Pátio encontrado</response>
        /// <response code="404">Pátio não encontrado</response>
        [HttpGet("{id}", Name = "GetPatioById")]
        [ProducesResponseType(typeof(PatioReadDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PatioReadDto>> GetPatioById(int id)
        {
            var patio = await _repo.GetPatioByIdAsync(id);
            if (patio == null) return NotFound();

            var dto = new PatioReadDto { Id = patio.Id, Nome = patio.Nome, Localizacao = patio.Localizacao };
            return Ok(dto);
        }

        /// <summary>
        /// Cria um novo pátio
        /// </summary>
        /// <param name="createDto">Dados do pátio a ser criado</param>
        /// <returns>Pátio criado com sucesso</returns>
        /// <response code="201">Pátio criado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(typeof(PatioReadDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PatioReadDto>> CreatePatio(PatioCreateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var patio = new Patio { Nome = createDto.Nome, Localizacao = createDto.Localizacao };
            await _repo.AddPatioAsync(patio);
            await _repo.SaveChangesAsync();

            var dto = new PatioReadDto { Id = patio.Id, Nome = patio.Nome, Localizacao = patio.Localizacao };
            return CreatedAtRoute("GetPatioById", new { id = patio.Id }, dto);
        }

        /// <summary>
        /// Atualiza um pátio existente
        /// </summary>
        /// <param name="id">ID do pátio a ser atualizado</param>
        /// <param name="updateDto">Dados atualizados do pátio</param>
        /// <returns>Confirmação da atualização</returns>
        /// <response code="204">Pátio atualizado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Pátio não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// Remove um pátio do sistema
        /// </summary>
        /// <param name="id">ID do pátio a ser removido</param>
        /// <returns>Confirmação da exclusão</returns>
        /// <response code="204">Pátio removido com sucesso</response>
        /// <response code="404">Pátio não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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
