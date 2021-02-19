using FinancNet.Models.Base;
using System;

namespace FinancNet.Models
{
    public class Transferencia : EntityBase
    {
        public long ContaDebitoId { get; set; }
        public virtual Conta ContaDebito { get; set; }

        public long ContaCreditoId { get; set; }
        public virtual Conta ContaCredito { get; set; }

        public DateTime Data { get; set; }

        public double Valor { get; set; }
    }
}
