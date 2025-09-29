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

        /// <summary>
        /// Lista todos os modelos de motos com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Itens por página (padrão: 10)</param>
        /// <returns>Lista paginada de modelos</returns>
        /// <response code="200">Lista de modelos retornada com sucesso</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ModeloReadDto>), 200)]
        public async Task<ActionResult<IEnumerable<ModeloReadDto>>> GetModelos([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var modelos = await _repo.GetModelosPagedAsync(pageNumber, pageSize);
            var total = await _repo.GetCountAsync();
            Response.Headers["X-Total-Count"] = total.ToString();

            var dtos = modelos.Select(m => new ModeloReadDto
            {
                Id = m.Id,
                Nome = m.Nome,
                Fabricante = m.Fabricante
            }).ToList();

            return Ok(dtos);
        }

        /// <summary>
        /// Busca um modelo específico por ID
        /// </summary>
        /// <param name="id">ID do modelo</param>
        /// <returns>Dados do modelo solicitado</returns>
        /// <response code="200">Modelo encontrado</response>
        /// <response code="404">Modelo não encontrado</response>
        [HttpGet("{id}", Name = "GetModeloById")]
        [ProducesResponseType(typeof(ModeloReadDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ModeloReadDto>> GetModeloById(int id)
        {
            var modelo = await _repo.GetModeloByIdAsync(id);
            if (modelo == null) return NotFound();

            var dto = new ModeloReadDto { Id = modelo.Id, Nome = modelo.Nome, Fabricante = modelo.Fabricante };
            return Ok(dto);
        }

        /// <summary>
        /// Cria um novo modelo de moto
        /// </summary>
        /// <param name="createDto">Dados do modelo a ser criado</param>
        /// <returns>Modelo criado com sucesso</returns>
        /// <response code="201">Modelo criado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(typeof(ModeloReadDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ModeloReadDto>> CreateModelo(ModeloCreateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var modelo = new Modelo { Nome = createDto.Nome, Fabricante = createDto.Fabricante };
            await _repo.AddModeloAsync(modelo);
            await _repo.SaveChangesAsync();

            var dto = new ModeloReadDto { Id = modelo.Id, Nome = modelo.Nome, Fabricante = modelo.Fabricante };
            return CreatedAtRoute("GetModeloById", new { id = modelo.Id }, dto);
        }

        /// <summary>
        /// Atualiza um modelo existente
        /// </summary>
        /// <param name="id">ID do modelo a ser atualizado</param>
        /// <param name="updateDto">Dados atualizados do modelo</param>
        /// <returns>Confirmação da atualização</returns>
        /// <response code="204">Modelo atualizado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Modelo não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// Remove um modelo do sistema
        /// </summary>
        /// <param name="id">ID do modelo a ser removido</param>
        /// <returns>Confirmação da exclusão</returns>
        /// <response code="204">Modelo removido com sucesso</response>
        /// <response code="404">Modelo não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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
