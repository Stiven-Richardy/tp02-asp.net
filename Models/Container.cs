using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP02.Models
{
    public class Container
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Número do Container é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O Número deve ter exatamente 11 caracteres.")]
        [RegularExpression(@"^[A-Za-z]{4}\d{7}$", ErrorMessage = "O formato deve ser 4 letras seguidas de 7 números (Ex: ABCD1234567).")]
        [Display(Name = "Identificação (Número)")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O Tipo é obrigatório.")]
        [RegularExpression("^(Dry|Reefer)$", ErrorMessage = "Selecione um tipo válido (Dry ou Reefer).")]
        [Display(Name = "Categoria (Tipo)")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O Tamanho é obrigatório.")]
        [RegularExpression("^(20|40)$", ErrorMessage = "O tamanho deve ser 20 ou 40 pés.")]
        [Display(Name = "Tamanho (Pés)")]
        public int Tamanho { get; set; }

        [Required(ErrorMessage = "A vinculação a um BL é obrigatória.")]
        [Display(Name = "Bill of Lading (BL Vinculado)")]
        public int BLId { get; set; }

        [ForeignKey("BLId")]
        public BL? BL { get; set; }
    }
}