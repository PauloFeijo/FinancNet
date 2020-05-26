using FinancNet.Models;
using System.Collections.Generic;

namespace FinancNet.Repositories
{
    public interface ILancamentoRepository : IRepository<Lancamento>
    {
        double GetTotalReceitas(long contaId);
        double GetTotalDespesas(long contaId);
    }
}
