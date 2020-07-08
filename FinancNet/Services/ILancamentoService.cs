using FinancNet.Models;
using System.Collections.Generic;

namespace FinancNet.Services
{
    public interface ILancamentoService : IService<Lancamento>
    {
        List<Lancamento> FindByPeriodo(string dini, string dfin);
    }
}
