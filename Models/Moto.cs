namespace API_NET.Models
{
    public class Moto
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Status { get; set; }
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }
        public int PatioId { get; set; }
        public Patio Patio { get; set; }
    }
}