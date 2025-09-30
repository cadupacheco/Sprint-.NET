using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sprint1.Dtos
{
    /// <summary>
    /// Dados necessários para criar uma nova moto
    /// </summary>
    public class MotoCreateDto
    {
        /// <summary>
        /// Placa da moto (formato ABC-1234)
        /// </summary>
        /// <example>ABC-1234</example>
        [Required(ErrorMessage = "A placa é obrigatória")]
        [StringLength(10, ErrorMessage = "A placa deve ter no máximo 10 caracteres")]
        public required string Placa { get; set; }

        /// <summary>
        /// Cor da moto
        /// </summary>
        /// <example>Vermelha</example>
        [Required(ErrorMessage = "A cor é obrigatória")]
        [StringLength(50, ErrorMessage = "A cor deve ter no máximo 50 caracteres")]
        public required string Cor { get; set; }

        /// <summary>
        /// Status da moto (available, maintenance, rented, out_of_service)
        /// </summary>
        /// <example>available</example>
        [StringLength(100, ErrorMessage = "O status deve ter no máximo 100 caracteres")]
        public string Status { get; set; } = "available";

        /// <summary>
        /// Coordenada X (latitude) da localização da moto
        /// </summary>
        /// <example>-23.5505</example>
        public double LocationX { get; set; }

        /// <summary>
        /// Coordenada Y (longitude) da localização da moto
        /// </summary>
        /// <example>-46.6333</example>
        public double LocationY { get; set; }

        /// <summary>
        /// Nível da bateria (0-100)
        /// </summary>
        /// <example>85</example>
        [Range(0, 100, ErrorMessage = "O nível da bateria deve estar entre 0 e 100")]
        public int BatteryLevel { get; set; } = 100;

        /// <summary>
        /// Nível de combustível (0-100)
        /// </summary>
        /// <example>75</example>
        [Range(0, 100, ErrorMessage = "O nível de combustível deve estar entre 0 e 100")]
        public int FuelLevel { get; set; } = 100;

        /// <summary>
        /// Quilometragem da moto
        /// </summary>
        /// <example>15000</example>
        [Range(0, int.MaxValue, ErrorMessage = "A quilometragem não pode ser negativa")]
        public int Mileage { get; set; } = 0;

        /// <summary>
        /// Data da próxima manutenção (ISO 8601)
        /// </summary>
        /// <example>2025-02-15T10:00:00Z</example>
        public string? NextMaintenanceDate { get; set; }

        /// <summary>
        /// Filial responsável pela moto
        /// </summary>
        /// <example>São Paulo Centro</example>
        [Required(ErrorMessage = "A filial é obrigatória")]
        [StringLength(100, ErrorMessage = "A filial deve ter no máximo 100 caracteres")]
        public required string AssignedBranch { get; set; } = "São Paulo Centro";

        /// <summary>
        /// Informações técnicas adicionais da moto
        /// </summary>
        /// <example>Bateria: 85%, Última manutenção: 15/01/2025</example>
        [StringLength(1000, ErrorMessage = "As informações técnicas devem ter no máximo 1000 caracteres")]
        public string? TechnicalInfo { get; set; }

        /// <summary>
        /// ID do modelo da moto
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "O ID do modelo é obrigatório")]
        public int ModeloId { get; set; }

        /// <summary>
        /// ID do pátio onde a moto ficará
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = "O ID do pátio é obrigatório")]
        public int PatioId { get; set; }
    }
}
