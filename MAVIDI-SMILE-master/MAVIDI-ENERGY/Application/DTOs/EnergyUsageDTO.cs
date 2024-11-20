using System;
using System.ComponentModel.DataAnnotations;

namespace MAVIDI_ENERGY.Application.DTOs
{
    public class EnergyUsageDTO
    {
        [Required(ErrorMessage = "O campo UserId é obrigatório")]
        public int UserId { get; set; } 

        [Required(ErrorMessage = "O campo Consumo Mensal é obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "O Consumo Mensal deve ser um valor positivo")]
        public decimal MonthlyConsumption { get; set; }

        [Required(ErrorMessage = "O campo Região é obrigatório")]
        [StringLength(100, ErrorMessage = "A Região deve ter no máximo 100 caracteres")]
        public string Region { get; set; }

        [Required(ErrorMessage = "O campo Custo Estimado é obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "O Custo Estimado deve ser um valor positivo")]
        public decimal EstimatedCost { get; set; }

        [Required(ErrorMessage = "O campo Emissões de CO2 é obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "As Emissões de CO2 devem ser um valor positivo")]
        public decimal CO2Emissions { get; set; }
    }
}