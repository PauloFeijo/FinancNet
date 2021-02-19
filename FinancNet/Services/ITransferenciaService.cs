using FinancNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinancNet.Services
{
    public interface ITransferenciaService : IService<Transferencia>
    {
        IQueryable<Transferencia> FindByPeriodo(string dini, string dfin);
    }
}
