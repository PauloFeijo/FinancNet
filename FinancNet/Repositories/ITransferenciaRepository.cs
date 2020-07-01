using FinancNet.Models;
using System.Collections.Generic;

namespace FinancNet.Repositories
{
    public interface ITransferenciaRepository : IRepository<Transferencia>
    {
        double GetTotalDebitos(long contaId);
        double GetTotalCreditos(long contaId);
    }
}
