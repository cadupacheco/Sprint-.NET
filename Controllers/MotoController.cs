using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sprint1.Dtos;
using Sprint1.Entities;
using Sprint1.Repositories;
using Sprint1.Helpers;

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
        /// Lista todas as motos com paginação
        /// </summary>
        /// <param name="pageNumber">Número da página (padrão: 1)</param>
        /// <param name="pageSize">Itens por página (padrão: 10)</param>
        /// <returns>Lista paginada de motos</returns>
        /// <response code="200">Lista de motos retornada com sucesso</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MotoReadDto>), 200)]
        public async Task<ActionResult<IEnumerable<MotoReadDto>>> GetMotos([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var motos = await _repo.GetMotosPagedAsync(pageNumber, pageSize);
            var total = await _repo.GetCountAsync();
            Response.Headers["X-Total-Count"] = total.ToString();

            var dtos = motos.Select(m => new MotoReadDto
            {
                Id = m.Id,
                Placa = m.Placa,
                Cor = m.Cor,
                ModeloId = m.ModeloId,
                PatioId = m.PatioId,
                DataRegistro = m.DataRegistro,
                NomeModelo = m.Modelo?.Nome,
                NomePatio = m.Patio?.Nome,
                
                // Campos extras para o app mobile
                Status = m.Status ?? "available",
                BatteryLevel = m.BatteryLevel,
                FuelLevel = m.FuelLevel,
                Location = new { x = m.LocationX, y = m.LocationY },
                Mileage = m.Mileage,
                TechnicalInfo = m.TechnicalInfo,
                NextMaintenanceDate = m.NextMaintenanceDate,
                AssignedBranch = m.AssignedBranch,
                LastUpdate = m.LastUpdate.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                
                Links = new List<LinkDto>
                {
                    new LinkDto { Rel = "próprio", Href = $"/api/moto/{m.Id}", Method = "GET" },
                    new LinkDto { Rel = "atualizar", Href = $"/api/moto/{m.Id}", Method = "PUT" },
                    new LinkDto { Rel = "excluir", Href = $"/api/moto/{m.Id}", Method = "DELETE" }
                }
            }).ToList();

            return Ok(dtos);
        }

        /// <summary>
        /// Busca uma moto específica por ID
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <returns>Dados da moto solicitada</returns>
        /// <response code="200">Moto encontrada</response>
        /// <response code="404">Moto não encontrada</response>
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
                ModeloId = moto.ModeloId,
                PatioId = moto.PatioId,
                DataRegistro = moto.DataRegistro,
                NomeModelo = moto.Modelo?.Nome,
                NomePatio = moto.Patio?.Nome,
                
                // Campos extras para o app mobile
                Status = moto.Status ?? "available",
                BatteryLevel = moto.BatteryLevel,
                FuelLevel = moto.FuelLevel,
                Location = new { x = moto.LocationX, y = moto.LocationY },
                Mileage = moto.Mileage,
                TechnicalInfo = moto.TechnicalInfo,
                NextMaintenanceDate = moto.NextMaintenanceDate,
                AssignedBranch = moto.AssignedBranch,
                LastUpdate = moto.LastUpdate.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                
                Links = new List<LinkDto>
                {
                    new LinkDto { Rel = "próprio", Href = $"/api/moto/{moto.Id}", Method = "GET" },
                    new LinkDto { Rel = "atualizar", Href = $"/api/moto/{moto.Id}", Method = "PUT" },
                    new LinkDto { Rel = "excluir", Href = $"/api/moto/{moto.Id}", Method = "DELETE" }
                }
            };

            return Ok(dto);
        }

        /// <summary>
        /// Cria uma nova moto
        /// </summary>
        /// <param name="createDto">Dados da moto a ser criada</param>
        /// <returns>Moto criada com sucesso</returns>
        /// <response code="201">Moto criada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(typeof(MotoReadDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<MotoReadDto>> CreateMoto(MotoCreateDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var moto = new Moto 
            { 
                Placa = createDto.Placa, 
                Cor = createDto.Cor,
                Status = createDto.Status,
                LocationX = createDto.LocationX,
                LocationY = createDto.LocationY,
                BatteryLevel = createDto.BatteryLevel,
                FuelLevel = createDto.FuelLevel,
                Mileage = createDto.Mileage,
                NextMaintenanceDate = createDto.NextMaintenanceDate,
                AssignedBranch = createDto.AssignedBranch,
                TechnicalInfo = createDto.TechnicalInfo,
                ModeloId = createDto.ModeloId,
                PatioId = createDto.PatioId,
                LastUpdate = DateTime.UtcNow,
                Modelo = null!,
                Patio = null!
            };
            
            await _repo.AddMotoAsync(moto);
            await _repo.SaveChangesAsync();

            moto = await _repo.GetMotoByIdAsync(moto.Id);

            var dto = new MotoReadDto
            {
                Id = moto.Id,
                Placa = moto.Placa,
                Cor = moto.Cor,
                ModeloId = moto.ModeloId,
                PatioId = moto.PatioId,
                DataRegistro = moto.DataRegistro,
                NomeModelo = moto.Modelo?.Nome,
                NomePatio = moto.Patio?.Nome,
                
                // Campos extras para o app mobile
                Status = moto.Status ?? "available",
                BatteryLevel = moto.BatteryLevel,
                FuelLevel = moto.FuelLevel,
                Location = new { x = moto.LocationX, y = moto.LocationY },
                Mileage = moto.Mileage,
                TechnicalInfo = moto.TechnicalInfo,
                NextMaintenanceDate = moto.NextMaintenanceDate,
                AssignedBranch = moto.AssignedBranch,
                LastUpdate = moto.LastUpdate.ToString("yyyy-MM-ddTHH:mm:ssZ")
            };

            return CreatedAtRoute("GetMotoById", new { id = moto.Id }, dto);
        }

        /// <summary>
        /// Atualiza uma moto existente
        /// </summary>
        /// <param name="id">ID da moto a ser atualizada</param>
        /// <param name="updateDto">Dados atualizados da moto</param>
        /// <returns>Confirmação da atualização</returns>
        /// <response code="204">Moto atualizada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Moto não encontrada</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateMoto(int id, MotoCreateDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var moto = await _repo.GetMotoByIdAsync(id);
            if (moto == null) return NotFound();

            moto.Placa = updateDto.Placa;
            moto.Cor = updateDto.Cor;
            moto.Status = updateDto.Status;
            moto.LocationX = updateDto.LocationX;
            moto.LocationY = updateDto.LocationY;
            moto.BatteryLevel = updateDto.BatteryLevel;
            moto.FuelLevel = updateDto.FuelLevel;
            moto.Mileage = updateDto.Mileage;
            moto.NextMaintenanceDate = updateDto.NextMaintenanceDate;
            moto.AssignedBranch = updateDto.AssignedBranch;
            moto.TechnicalInfo = updateDto.TechnicalInfo;
            moto.ModeloId = updateDto.ModeloId;
            moto.PatioId = updateDto.PatioId;
            moto.LastUpdate = DateTime.UtcNow;

            await _repo.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Remove uma moto do sistema
        /// </summary>
        /// <param name="id">ID da moto a ser removida</param>
        /// <returns>Confirmação da exclusão</returns>
        /// <response code="204">Moto removida com sucesso</response>
        /// <response code="404">Moto não encontrada</response>
        [HttpDelete("{id}")]
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
    }
}
