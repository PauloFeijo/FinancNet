using FinancNet.Entities;
using FinancNet.Interfaces.Repositories.Base;
using System.Linq;

namespace FinancNet.Interfaces.Repositories
{
    public interface ITransferRepository : IRepositoryBase<Transfer>
    {
        double GetTotalDebit(long accountId);
        double GetTotalCredit(long accountId);
        IQueryable<Transfer> FindByPeriod(string dini, string dfin);
    }
}
