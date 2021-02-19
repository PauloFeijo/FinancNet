using FinancNet.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancNet.Models
{
    public class Conta : EntityBase
    {
        [Required]
        public string Descricao { get; set; }

        public string Numero { get; set; }

        [Required]
        public double Saldo { get; set; }
    }
}
