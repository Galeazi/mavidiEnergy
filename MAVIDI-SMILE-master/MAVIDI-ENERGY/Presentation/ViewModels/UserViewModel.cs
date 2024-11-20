using System.ComponentModel.DataAnnotations;

namespace MAVIDI_ENERGY.Presentation.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "A Senha deve ter entre 6 e 50 caracteres.")]
        public string Password { get; set; }
    }
}