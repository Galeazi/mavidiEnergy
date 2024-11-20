using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAVIDI_SMILE.mavidiSmile.Domain.Entities
{
    [Table("tb_niveis")]
    public class Nivel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NivelAtual { get; set; }

        [Required]
        public int Experiencia { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}