using System;

namespace FinancNet.Models
{
    public class Lancamento : Entity
    {
        public DateTime data { get; set; }

        public string tipo { get; set; }

        public string descricao { get; set; }

        public double valor { get; set; }

        public long contaId { get; set; }
        public virtual Conta conta { get; set; }

        public long categoriaId { get; set; }
        public virtual Categoria categoria { get; set; }        
    }
}
