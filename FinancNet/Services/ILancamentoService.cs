using FinancNet.Models;
using FinancNet.Services.Base;
using System.Linq;

namespace FinancNet.Services
{
    public interface ILancamentoService : IServiceBase<Lancamento>
    {
        IQueryable<Lancamento> FindByPeriodo(string dini, string dfin);
    }
}
