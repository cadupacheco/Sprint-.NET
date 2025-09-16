using System;
using System.Collections.Generic;
using Sprint1.Helpers;

namespace Sprint1.Dtos
{
    public class MotoReadDto
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string NomeModelo { get; set; }
        public string NomePatio { get; set; }
        public DateTime DataRegistro { get; set; }
        public List<LinkDto> Links { get; set; }
    }
}
