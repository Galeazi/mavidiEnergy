using System.ComponentModel.DataAnnotations;

namespace MAVIDI_SMILE.ViewModels
{
    public class AmigoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido.")]
        public string Email { get; set; }
    }
}