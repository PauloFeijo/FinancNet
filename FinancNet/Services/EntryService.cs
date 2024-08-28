using FinancNet.Entities;
using FinancNet.Interfaces.Repositories;
using FinancNet.Interfaces.Services;
using FinancNet.Interfaces.Services.Base;
using FinancNet.Services.Base;
using System.Linq;

namespace FinancNet.Services
{
    public class EntryService : ServiceBase<Entry>, IEntryService
    {
        private readonly IEntryRepository _repo;
        private readonly IServiceBase<Category> _servCateg;
        private readonly IBalanceService _servBal;

        public EntryService(IEntryRepository repo, IServiceBase<Category> servCateg, IBalanceService servBal) : base(repo)
        {
            _repo = repo;
            _servCateg = servCateg;
            _servBal = servBal;
        }

        public override Entry Create(Entry item)
        {
            SetType(item);
            Entry lanc = base.Create(item);
            _servBal.Process(item.AccountId);
            return lanc;
        }

        public override Entry Update(Entry item)
        {
            long oldAccountId = FindById(item.Id).AccountId;

            SetType(item);
            Entry lanc = base.Update(item);

            if (item.AccountId != oldAccountId)
            {
                _servBal.Process(oldAccountId);
            }
            _servBal.Process(item.AccountId);

            return lanc;
        }

        public override void Delete(long id)
        {
            long accountId = FindById(id).AccountId;
            base.Delete(id);
            _servBal.Process(accountId);
        }

        public IQueryable<Entry> FindByPeriod(string dini, string dfin) =>
            _repo.FindByPeriod(dini, dfin);

        private void SetType(Entry item)
        {
            Category cat = _servCateg.FindById(item.CategoryId);
            if (cat != null)
            {
                item.Type = cat.Type;
            }
        }
    }
}
