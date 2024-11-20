using System.ComponentModel.DataAnnotations;

namespace MAVIDI_SMILE.ViewModels
{
    public class ProgressoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A atividade é obrigatória.")]
        public string Atividade { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime Data { get; set; }

        public int UsuarioId { get; set; }
    }
}