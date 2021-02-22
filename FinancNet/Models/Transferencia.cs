using FinancNet.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancNet.Models
{
    public class Transferencia : EntityBase
    {
        [Required]
        public long ContaDebitoId { get; set; }

        [Required]
        public long ContaCreditoId { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public double Valor { get; set; }

        public virtual Conta ContaDebito { get; set; }

        public virtual Conta ContaCredito { get; set; }
    }
}
