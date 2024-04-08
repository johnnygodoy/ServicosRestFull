using System.ComponentModel.DataAnnotations;

namespace TelaVinho.Models
{
    public class Vinhos
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
