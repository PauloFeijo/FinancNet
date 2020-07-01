using System;

namespace FinancNet.Models
{
    public class Transferencia : Entity
    {
        public long contaDebitoId { get; set; }
        public virtual Conta contaDebito { get; set; }

        public long contaCreditoId { get; set; }
        public virtual Conta contaCredito { get; set; }

        public DateTime data { get; set; }

        public double valor { get; set; }
    }
}
