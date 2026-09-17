using System.ComponentModel.DataAnnotations;

namespace TP02.Models
{
    public class BL
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Número do BL é obrigatório.")]
        [Display(Name = "Número do BL")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O Consignatário é obrigatório.")]
        [Display(Name = "Consignatário (Destinatário)")]
        public string Consignee { get; set; }

        [Required(ErrorMessage = "O Navio é obrigatório.")]
        [Display(Name = "Nome do Navio")]
        public string Navio { get; set; }

        public ICollection<Container> Containers { get; set; } = new List<Container>();
    }
}