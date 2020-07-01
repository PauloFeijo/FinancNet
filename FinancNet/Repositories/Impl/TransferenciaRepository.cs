using FinancNet.Models;
using FinancNet.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinancNet.Repositories.Impl
{
    public class TransferenciaRepository : Repository<Transferencia>, ITransferenciaRepository
    {
        public TransferenciaRepository(Contexto ctx) : base(ctx) {}


        public override List<Transferencia> FindAll()
        {
            return dataset
                .Include("contaDebito")
                .Include("contaCredito")
                .ToList();
        }

        public double GetTotalCreditos(long contaId)
        {
            return dataset
                .Where(t => t.contaCreditoId == contaId)
                .Sum(t => t.valor);
        }

        public double GetTotalDebitos(long contaId)
        {
            return dataset
                .Where(t => t.contaDebitoId == contaId)
                .Sum(t => t.valor);
        }
    }
}
