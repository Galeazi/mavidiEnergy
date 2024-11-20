using System.ComponentModel.DataAnnotations;

namespace MAVIDI_ENERGY.Application.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "O campo Name é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo Name deve ter no máximo 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O Email inserido não é válido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Password é obrigatório")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 50 caracteres")]
        public string Password { get; set; } = string.Empty;
    }
}