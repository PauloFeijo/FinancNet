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

        private double GetTotalReceitasDespesas(long contaId, string tipo)
        {
            return dataset
                .Where(l => l.contaId == contaId && l.tipo.ToUpper() == tipo)
                .Sum(l => l.valor);
        }

        public override List<Lancamento> FindAll()
        {
            return dataset
                .Include("conta")
                .Include("categoria")
                .ToList();
        }

        public double GetTotalDespesas(long contaId)
        {
            return GetTotalReceitasDespesas(contaId, "DESPESA");
        }

        public double GetTotalReceitas(long contaId)
        {
            return GetTotalReceitasDespesas(contaId, "RECEITA");
        }
    }
}
