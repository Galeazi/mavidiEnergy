using MAVIDI_SMILE.mavidiSmile.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAVIDI_SMILE.Domain.Entities
{
    [Table("tb_amigos")]
    public class Amigo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        [ForeignKey("AmigoUsuario")]
        public int AmigoId { get; set; }
        public required Usuario AmigoUsuario { get; set; }
    }
}
