using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancNet.Models
{
    public class Conta
    {
        public long id { get; set; }
        public String descricao { get; set; }
        public String numero { get; set; }
        public Double saldo { get; set; }

        public Conta(long id, String descricao, String numero, Double saldo)
        {
            this.id = id;
            this.descricao = descricao;
            this.numero = numero;
            this.saldo = saldo;
        }
    }
}
