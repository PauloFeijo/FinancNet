using System;
using System.ComponentModel.DataAnnotations;

namespace FinancNet.Models
{
    public class Conta : Entity
    {
        [Required]
        public String descricao { get; set; }

        public String numero { get; set; }

        [Required]
        public Double saldo { get; set; }
    }
}
