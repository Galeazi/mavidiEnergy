using System;
using System.ComponentModel.DataAnnotations;

namespace MAVIDI_SMILE.mavidiSmile.Application.DTOs
{
    public class RegistroProgressoDTO
    {
        [Required(ErrorMessage = $"Campo {nameof(UsuarioId)} é obrigatório")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(Atividade)} é obrigatório")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "A atividade deve ter no mínimo 5 caracteres")]
        public string Atividade { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Data)} é obrigatório")]
        public DateTime Data { get; set; } = DateTime.Now;
    }
}