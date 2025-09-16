using System.ComponentModel.DataAnnotations;

namespace Sprint1.Dtos
{
    public class MotoCreateDto
    {
        [Required]
        public string Placa { get; set; }

        [Required]
        public string Cor { get; set; }

        [Required]
        public int ModeloId { get; set; }

        [Required]
        public int PatioId { get; set; }
    }
}
