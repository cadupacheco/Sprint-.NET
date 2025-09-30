using System;
using System.Collections.Generic;
using Sprint1.Helpers;

namespace Sprint1.Dtos
{
    public class MotoReadDto
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Cor { get; set; } = string.Empty;
        public int ModeloId { get; set; }
        public int PatioId { get; set; }
        public string? NomeModelo { get; set; }
        public string? NomePatio { get; set; }
        public DateTime DataRegistro { get; set; }
        
        // Campos extras para o app mobile
        public string Status { get; set; } = "available";
        public int BatteryLevel { get; set; } = 85;
        public int FuelLevel { get; set; } = 75;
        public object? Location { get; set; }
        public int Mileage { get; set; } = 0;
        public string? TechnicalInfo { get; set; }
        public string? NextMaintenanceDate { get; set; }
        public string? AssignedBranch { get; set; }
        public string? LastUpdate { get; set; }
        
        public List<LinkDto>? Links { get; set; }
    }
}
