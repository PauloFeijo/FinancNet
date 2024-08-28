using FinancNet.Entities;
using FinancNet.Interfaces.Repositories;
using FinancNet.Interfaces.Services;
using FinancNet.Services.Base;
using System.Linq;

namespace FinancNet.Services
{
    public class TransferService : ServiceBase<Transfer>, ITransferService
    {
        private readonly ITransferRepository _repo;
        private readonly IBalanceService _balanceServ;

        public TransferService(ITransferRepository repo, IBalanceService balanceServ) : base(repo)
        {
            _repo = repo;
            _balanceServ = balanceServ;
        }

        public override Transfer Create(Transfer item)
        {
            Transfer transf = base.Create(item);
            _balanceServ.Process(item.DebitAccountId);
            _balanceServ.Process(item.CreditAccountId);
            return transf;
        }

        public override Transfer Update(Transfer item)
        {
            Transfer transf = FindById(item.Id);

            if (transf == null)
            {
                return null;
            }

            long oldAccountDebitId = transf.DebitAccountId;
            long oldAccountCreditId = transf.CreditAccountId;

            transf = base.Update(item);

            if (item.DebitAccountId != oldAccountDebitId)
            {
                _balanceServ.Process(oldAccountDebitId);
            }
            _balanceServ.Process(item.DebitAccountId);

            if (item.CreditAccountId != oldAccountCreditId)
            {
                _balanceServ.Process(oldAccountCreditId);
            }
            _balanceServ.Process(item.CreditAccountId);

            return transf;
        }

        public override void Delete(long id)
        {
            Transfer transf = FindById(id);

            if (transf == null)
            {
                return;
            }

            long debitAccountId = transf.DebitAccountId;
            long creditAccountId = transf.CreditAccountId;

            base.Delete(id);

            _balanceServ.Process(debitAccountId);
            _balanceServ.Process(creditAccountId);
        }

        public IQueryable<Transfer> FindByPeriod(string dini, string dfin)
        {
            return _repo.FindByPeriod(dini, dfin);
        }
    }
}
