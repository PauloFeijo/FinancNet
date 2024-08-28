using FinancNet.Entities;
using FinancNet.Interfaces.Services.Base;
using System.Linq;

namespace FinancNet.Interfaces.Services
{
    public interface ITransferService : IServiceBase<Transfer>
    {
        IQueryable<Transfer> FindByPeriod(string dini, string dfin);
    }
}
