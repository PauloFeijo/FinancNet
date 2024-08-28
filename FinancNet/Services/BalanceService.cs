using FinancNet.Entities;
using FinancNet.Interfaces.Repositories;
using FinancNet.Interfaces.Services;
using FinancNet.Interfaces.Services.Base;

namespace FinancNet.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IEntryRepository _entryRepo;
        private readonly ITransferRepository _transfRepo;
        private readonly IServiceBase<Account> _accountServ;

        public BalanceService(IEntryRepository entryRepo, ITransferRepository transfRepo, IServiceBase<Account> accountServ)
        {
            _entryRepo = entryRepo;
            _transfRepo = transfRepo;
            _accountServ = accountServ;
        }

        public void Process(long accountId)
        {
            Account account = _accountServ.FindById(accountId);
            if (account == null)
            {
                return;
            }
            double revenue = _entryRepo.GetTotalRevenue(accountId) + _transfRepo.GetTotalCredit(accountId);
            double expense = _entryRepo.GetTotalExpense(accountId) + _transfRepo.GetTotalDebit(accountId);

            account.Balance = revenue - expense;

            _accountServ.Update(account);
        }
    }
}
