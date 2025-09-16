using System.ComponentModel.DataAnnotations;

namespace Sprint1.Dtos
{
    public class ModeloCreateDto
    {
        [Required]
        public string Nome { get; set; }

        public string Fabricante { get; set; }
    }
}
