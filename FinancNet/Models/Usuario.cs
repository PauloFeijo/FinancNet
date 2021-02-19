using System.ComponentModel.DataAnnotations;

namespace FinancNet.Models
{
    public class Usuario
    {
        [Key]
        public string Login { get; set; }
        public string Senha { get; set; }
        public string  Nome { get; set; }
        public static string Logado { get; set; }
    }
}
