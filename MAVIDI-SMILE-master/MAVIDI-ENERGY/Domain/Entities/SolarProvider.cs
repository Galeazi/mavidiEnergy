using System.ComponentModel.DataAnnotations;

namespace MAVIDI_ENERGY.Domain.Entities
{
    public class SolarProvider
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Localização é obrigatório")]
        [StringLength(200, ErrorMessage = "A Localização deve ter no máximo 200 caracteres")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Informações de Contato é obrigatório")]
        [StringLength(50, ErrorMessage = "As Informações de Contato devem ter no máximo 50 caracteres")]
        public string ContactInfo { get; set; } = string.Empty;

        [Range(0, 5, ErrorMessage = "A Avaliação deve estar entre 0 e 5")]
        public double Rating { get; set; } 
    }
}