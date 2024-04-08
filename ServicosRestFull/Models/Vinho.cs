using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicosRestFull.Models
{
    [Table("vinho")]
    public class Vinho
    {
        [Key]
        public int Cod_vinho { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Campo inválido!", MinimumLength = 4)]
        public string Nome_vinho { get; set; }
        public int Idade_vinho { get; set; }

        [DataType(DataType.Currency)]
        public decimal Preco_vinho { get; set; }
    }
}
