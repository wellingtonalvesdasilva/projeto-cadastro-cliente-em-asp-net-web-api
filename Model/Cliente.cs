using Arquitetura.Entity;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Cliente : EntityBase
    {
        [Display(Name = "Código")]
        [Required]
        [MaxLength(15)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Display(Name = "CPF/CNPJ")]
        [Required]
        [MaxLength(14)]
        public string CPF_CNPJ { get; set; }

        [Required]
        [MaxLength(11)]
        public string Telefone { get; set; }
    }
}
