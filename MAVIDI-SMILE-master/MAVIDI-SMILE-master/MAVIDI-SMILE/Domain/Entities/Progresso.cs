using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAVIDI_SMILE.mavidiSmile.Domain.Entities
{
    [Table("tb_progresso")]
    public class Progresso
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Data { get; set; } = DateTime.Now;

        [Required]
        public string Atividade { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}