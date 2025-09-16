using System.ComponentModel.DataAnnotations;

namespace Sprint1.Dtos
{
    public class PatioCreateDto
    {
        [Required]
        public string Nome { get; set; }

        public string Localizacao { get; set; }
    }
}
