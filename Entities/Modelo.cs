using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sprint1.Entities
{
    public class Modelo
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Fabricante { get; set; }

        public ICollection<Moto> Motos { get; set; }
    }
}
