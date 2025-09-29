using System;
using System.Collections.Generic;
using Sprint1.Helpers;

namespace Sprint1.Dtos
{
    public class MotoReadDto
    {
        public int Id { get; set; }
        public string? Placa { get; set; }
        public string? Cor { get; set; }
        public string? NomeModelo { get; set; }
        public string? NomePatio { get; set; }
        public DateTime DataRegistro { get; set; }
        public int ModeloId { get; set; }
        public int PatioId { get; set; }
        public List<LinkDto>? Links { get; set; }

        public string? Model { get; set; }
        public string? Plate { get; set; }
        public string? Status { get; set; }
        public int BatteryLevel { get; set; }
        public int FuelLevel { get; set; }
        public object? Location { get; set; }
        public int Mileage { get; set; }
        public string? TechnicalInfo { get; set; }
        public string? NextMaintenanceDate { get; set; }
        public string? AssignedBranch { get; set; }
        public string? LastUpdate { get; set; }
    }
}
