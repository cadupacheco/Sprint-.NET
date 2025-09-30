using System;
using System.ComponentModel.DataAnnotations;

namespace Sprint1.Entities
{
    public class Moto
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public required string Placa { get; set; }

        [Required, StringLength(50)]
        public required string Cor { get; set; }

        [Required, StringLength(100)]
        public required string Status { get; set; } = "available";

        public double LocationX { get; set; }
        public double LocationY { get; set; }

        public int BatteryLevel { get; set; } = 100;
        public int FuelLevel { get; set; } = 100;
        public int Mileage { get; set; } = 0;

        [StringLength(19)]
        public string? NextMaintenanceDate { get; set; }

        [Required, StringLength(100)]
        public required string AssignedBranch { get; set; } = "São Paulo Centro";

        [StringLength(1000)]
        public string? TechnicalInfo { get; set; }

        public int ModeloId { get; set; }
        public required Modelo Modelo { get; set; }

        public int PatioId { get; set; }
        public required Patio Patio { get; set; }

        public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
    }
}
