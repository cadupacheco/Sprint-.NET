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
