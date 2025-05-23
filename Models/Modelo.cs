namespace API_NET.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Moto> Motos { get; set; }
    }
}