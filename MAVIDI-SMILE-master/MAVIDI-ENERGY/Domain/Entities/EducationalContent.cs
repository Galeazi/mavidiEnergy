using System;
using System.ComponentModel.DataAnnotations;

namespace MAVIDI_ENERGY.Domain.Entities
{
    public class EducationalContent
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [StringLength(200, ErrorMessage = "O título deve ter no máximo 200 caracteres.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Conteúdo é obrigatório.")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Data de Criação é obrigatório.")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}