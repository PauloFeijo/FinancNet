using FinancNet.Models;
using FinancNet.Repositories.Base;
using System.Linq;

namespace FinancNet.Repositories
{
    public interface ILancamentoRepository : IRepositoryBase<Lancamento>
    {
        double GetTotalReceitas(long contaId);
        double GetTotalDespesas(long contaId);
        IQueryable<Lancamento> FindByPeriodo(string dini, string dfin);
    }
}
