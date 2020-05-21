using FinancNet.Models;
using FinancNet.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq;

namespace FinancNet.Repositories.Impl
{
    public class LancamentoRepository : Repository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(Contexto ctx) : base(ctx) {}

        public override List<Lancamento> FindAll()
        {
            return dataset
                .Include("conta")
                .Include("categoria")
                .ToList();
        }
    }
}
