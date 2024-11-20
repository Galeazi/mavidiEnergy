using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAVIDI_ENERGY.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "O Email é inválido.")]
        public string Email { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "O Hash da Senha deve ter no máximo 255 caracteres.")]
        public string PasswordHash { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}