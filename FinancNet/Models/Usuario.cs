using System.ComponentModel.DataAnnotations;

namespace FinancNet.Models
{
    public class Usuario
    {
        [Key]
        public string login { get; set; }
        public string senha { get; set; }
        public string  nome { get; set; }
        public static string logado { get; set; }
    }
}
