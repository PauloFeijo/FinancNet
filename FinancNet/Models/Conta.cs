using FinancNet.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancNet.Models
{
    public class Conta : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        [StringLength(15)]
        public string Numero { get; set; }

        [Required]
        public double Saldo { get; set; }
    }
}
