using MAVIDI_SMILE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAVIDI_SMILE.mavidiSmile.Domain.Entities
{
    [Table("tb_usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public ICollection<Progresso> Progresso { get; set; }
        public ICollection<Nivel> Niveis { get; set; }
        public ICollection<Amigo> Amigos { get; set; }
    }
}