using System;
using System.ComponentModel.DataAnnotations;

namespace MAVIDI_SMILE.mavidiSmile.Application.DTOs
{
    public class AmigosDTO
    {
        [Required(ErrorMessage = $"Campo {nameof(UsuarioId)} é obrigatório")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(AmigoId)} é obrigatório")]
        public int AmigoId { get; set; }
    }
}