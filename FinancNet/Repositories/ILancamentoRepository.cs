using FinancNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinancNet.Repositories
{
    public interface ILancamentoRepository : IRepository<Lancamento>
    {
        double GetTotalReceitas(long contaId);
        double GetTotalDespesas(long contaId);
        IQueryable<Lancamento> FindByPeriodo(string dini, string dfin);
    }
}
