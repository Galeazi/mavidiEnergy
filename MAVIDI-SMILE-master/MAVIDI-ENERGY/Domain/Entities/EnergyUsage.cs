using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAVIDI_ENERGY.Domain.Entities
{
    public class EnergyUsage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo UserId é obrigatório.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O campo MonthlyConsumption é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O consumo mensal deve ser um valor positivo.")]
        public decimal MonthlyConsumption { get; set; } 

        [Required(ErrorMessage = "O campo Region é obrigatório.")]
        [StringLength(100, ErrorMessage = "A região deve ter no máximo 100 caracteres.")]
        public string Region { get; set; }

        [Required(ErrorMessage = "O campo EstimatedCost é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O custo estimado deve ser um valor positivo.")]
        public decimal EstimatedCost { get; set; } 

        [Required(ErrorMessage = "O campo CO2Emissions é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "As emissões de CO₂ devem ser um valor positivo.")]
        public decimal CO2Emissions { get; set; } 

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}