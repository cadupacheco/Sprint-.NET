using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sprint1.Entities
{
    public class Patio
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Localizacao { get; set; }

        public ICollection<Moto> Motos { get; set; }
    }
}
