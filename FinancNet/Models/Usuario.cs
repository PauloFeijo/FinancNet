using System.ComponentModel.DataAnnotations;

namespace FinancNet.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        [StringLength(15)]
        public string Login { get; set; }

        [Required]
        [StringLength(15)]
        public string Senha { get; set; }

        [Required]
        [StringLength(50)]
        public string  Nome { get; set; }

        public static string Logado { get; set; }
    }
}
