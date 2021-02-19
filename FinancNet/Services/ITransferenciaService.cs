using FinancNet.Models;
using FinancNet.Services.Base;
using System.Linq;

namespace FinancNet.Services
{
    public interface ITransferenciaService : IServiceBase<Transferencia>
    {
        IQueryable<Transferencia> FindByPeriodo(string dini, string dfin);
    }
}
