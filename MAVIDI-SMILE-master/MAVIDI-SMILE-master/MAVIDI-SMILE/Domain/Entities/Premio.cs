using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAVIDI_SMILE.mavidiSmile.Domain.Entities
{
    [Table("tb_premios")]
    public class Premio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public int PontuacaoNecessaria { get; set; }
    }
}