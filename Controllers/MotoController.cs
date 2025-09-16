using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sprint1.Dtos;
using Sprint1.Entities;
using Sprint1.Helpers;
using Sprint1.Repositories;

namespace Sprint1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly IMotoRepository _repo;

        public MotoController(IMotoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista motos com paginação.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MotoReadDto>), 200)]
        public async Task<ActionResult<IEnumerable<MotoReadDto>>> GetMotos([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var motos = await _repo.GetMotosPagedAsync(pageNumber, pageSize);
            var total = await _repo.GetCountAsync();
            Response.Headers.Add("X-Total-Count", total.ToString());

            var dtos = motos.Select(m => new MotoReadDto
            {
                Id = m.Id,
                Placa = m.Placa,
                Cor = m.Cor,
                NomeModelo = m.Modelo?.Nome,
                NomePatio = m.Patio?.Nome,
                DataRegistro = m.DataRegistro,
                Links = CreateLinksForMoto(m.Id)
            }).ToList();

            return Ok(dtos);
        }

        /// <summary>
        /// Obtém uma moto por id.
        /// </summary>
        [HttpGet("{id}", Name = "GetMotoById")]
        [ProducesResponseType(typeof(MotoReadDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MotoReadDto>> GetMotoById(int id)
        {
            var moto = await _repo.GetMotoByIdAsync(id);
            if (moto == null) return NotFound();

            var dto = new MotoReadDto
            {
                Id = moto.Id,
                Placa = moto.Placa,
                Cor = moto.Cor,
                NomeModelo = moto.Modelo?.Nome,
                NomePatio = moto.Patio?.Nome,
                DataRegistro = moto.DataRegistro,
                Links = CreateLinksForMoto(moto.Id)
            };

            return Ok(dto);
        }

        /// <summary>
        /// Cria uma nova moto.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(MotoReadDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<MotoReadDto>> CreateMoto([FromBody] MotoCreateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var moto = new Moto
            {
                Placa = createDto.Placa,
                Cor = createDto.Cor,
                ModeloId = createDto.ModeloId,
                PatioId = createDto.PatioId
            };

            await _repo.AddMotoAsync(moto);
            await _repo.SaveChangesAsync();

            var readDto = new MotoReadDto
            {
                Id = moto.Id,
                Placa = moto.Placa,
                Cor = moto.Cor,
                NomeModelo = moto.Modelo?.Nome,
                NomePatio = moto.Patio?.Nome,
                DataRegistro = moto.DataRegistro,
                Links = CreateLinksForMoto(moto.Id)
            };

            return CreatedAtRoute("GetMotoById", new { id = moto.Id }, readDto);
        }

        /// <summary>
        /// Atualiza uma moto.
        /// </summary>
        [HttpPut("{id}", Name = "UpdateMoto")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateMoto(int id, [FromBody] MotoCreateDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var moto = await _repo.GetMotoByIdAsync(id);
            if (moto == null) return NotFound();

            moto.Placa = updateDto.Placa;
            moto.Cor = updateDto.Cor;
            moto.ModeloId = updateDto.ModeloId;
            moto.PatioId = updateDto.PatioId;

            await _repo.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deleta uma moto.
        /// </summary>
        [HttpDelete("{id}", Name = "DeleteMoto")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMoto(int id)
        {
            var moto = await _repo.GetMotoByIdAsync(id);
            if (moto == null) return NotFound();

            _repo.DeleteMoto(moto);
            await _repo.SaveChangesAsync();

            return NoContent();
        }

        private List<LinkDto> CreateLinksForMoto(int id)
        {
            return new List<LinkDto>
            {
                new LinkDto { Rel = "self", Href = Url.Link("GetMotoById", new { id }), Method = "GET" },
                new LinkDto { Rel = "update", Href = Url.Link("UpdateMoto", new { id }), Method = "PUT" },
                new LinkDto { Rel = "delete", Href = Url.Link("DeleteMoto", new { id }), Method = "DELETE" }
            };
        }
    }
}
