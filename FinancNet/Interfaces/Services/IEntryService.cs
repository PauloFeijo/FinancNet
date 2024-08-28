using FinancNet.Entities;
using FinancNet.Interfaces.Services.Base;
using System.Linq;

namespace FinancNet.Interfaces.Services
{
    public interface IEntryService : IServiceBase<Entry>
    {
        IQueryable<Entry> FindByPeriod(string dini, string dfin);
    }
}
