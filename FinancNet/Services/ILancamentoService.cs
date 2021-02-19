using FinancNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinancNet.Services
{
    public interface ILancamentoService : IService<Lancamento>
    {
        IQueryable<Lancamento> FindByPeriodo(string dini, string dfin);
    }
}
