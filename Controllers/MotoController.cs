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

        [HttpGet]
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
                
                // Campos compatíveis com o app mobile
                Model = m.Modelo?.Nome ?? "Modelo não informado",
                Plate = m.Placa,
                Status = "disponível", // Status padrão
                BatteryLevel = 85, // Nível da bateria padrão
                FuelLevel = 90, // Nível de combustível padrão
                Location = new { x = -23.5505, y = -46.6333 }, // São Paulo padrão
                Mileage = 15000, // Quilometragem padrão
                TechnicalInfo = "Informações técnicas da moto",
                NextMaintenanceDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd"),
                AssignedBranch = "São Paulo Centro",
                LastUpdate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                
                Links = new List<LinkDto>
                {
                    new LinkDto { Rel = "próprio", Href = $"/api/moto/{m.Id}", Method = "GET" },
                    new LinkDto { Rel = "atualizar", Href = $"/api/moto/{m.Id}", Method = "PUT" },
                    new LinkDto { Rel = "excluir", Href = $"/api/moto/{m.Id}", Method = "DELETE" }
                }
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetMotoById")]
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
                
                // Campos compatíveis com o app mobile
                Model = moto.Modelo?.Nome ?? "Modelo não informado",
                Plate = moto.Placa,
                Status = "disponível",
                BatteryLevel = 85,
                FuelLevel = 90,
                Location = new { x = -23.5505, y = -46.6333 },
                Mileage = 15000,
                TechnicalInfo = "Informações técnicas da moto",
                NextMaintenanceDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd"),
                AssignedBranch = "São Paulo Centro",
                LastUpdate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                
                Links = new List<LinkDto>
                {
                    new LinkDto { Rel = "próprio", Href = $"/api/moto/{moto.Id}", Method = "GET" },
                    new LinkDto { Rel = "atualizar", Href = $"/api/moto/{moto.Id}", Method = "PUT" },
                    new LinkDto { Rel = "excluir", Href = $"/api/moto/{moto.Id}", Method = "DELETE" }
                }
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<MotoReadDto>> CreateMoto(MotoCreateDto createDto)
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

            // Recarregar com includes
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
                
                // Campos compatíveis com o app mobile
                Model = moto.Modelo?.Nome ?? "Modelo não informado",
                Plate = moto.Placa,
                Status = "disponível",
                BatteryLevel = 85,
                FuelLevel = 90,
                Location = new { x = -23.5505, y = -46.6333 },
                Mileage = 15000,
                TechnicalInfo = "Informações técnicas da moto",
                NextMaintenanceDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd"),
                AssignedBranch = "São Paulo Centro",
                LastUpdate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
            };

            return CreatedAtRoute("GetMotoById", new { id = moto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMoto(int id, MotoCreateDto updateDto)
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

        [HttpDelete("{id}")]
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
