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
    }
}
