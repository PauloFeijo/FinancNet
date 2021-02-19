using FinancNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinancNet.Repositories
{
    public interface ITransferenciaRepository : IRepository<Transferencia>
    {
        double GetTotalDebitos(long contaId);
        double GetTotalCreditos(long contaId);
        IQueryable<Transferencia> FindByPeriodo(string dini, string dfin);
    }
}
