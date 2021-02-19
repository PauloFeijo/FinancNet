using FinancNet.Models;
using FinancNet.Repositories.Base;
using System.Linq;

namespace FinancNet.Repositories
{
    public interface ITransferenciaRepository : IRepositoryBase<Transferencia>
    {
        double GetTotalDebitos(long contaId);
        double GetTotalCreditos(long contaId);
        IQueryable<Transferencia> FindByPeriodo(string dini, string dfin);
    }
}
