using System;
using System.ComponentModel.DataAnnotations;

namespace Sprint1.Entities
{
    public class Moto
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Placa { get; set; }

        [Required, StringLength(50)]
        public string Cor { get; set; }

        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }

        public int PatioId { get; set; }
        public Patio Patio { get; set; }

        public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    }
}
