using FinancNet.Entities;
using FinancNet.Interfaces.Repositories.Base;
using System.Linq;

namespace FinancNet.Interfaces.Repositories
{
    public interface IEntryRepository : IRepositoryBase<Entry>
    {
        double GetTotalRevenue(long accountId);
        double GetTotalExpense(long accountId);
        IQueryable<Entry> FindByPeriod(string dini, string dfin);
    }
}
