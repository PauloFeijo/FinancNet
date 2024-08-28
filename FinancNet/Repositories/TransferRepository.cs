using FinancNet.Entities;
using FinancNet.Interfaces.Repositories;
using FinancNet.Repositories.Base;
using FinancNet.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace FinancNet.Repositories
{
    public class TransferRepository : RepositoryBase<Transfer>, ITransferRepository
    {
        public TransferRepository(Context.Context ctx) : base(ctx) { }

        public override IQueryable<Transfer> FindAll() => _dbset
            .Include("DebitAccount")
            .Include("CreditAccount")
            .Where(t => t.User.Equals(User.LoggedUser));

        public double GetTotalCredit(long accountId) => _dbset
            .Where(t => t.CreditAccountId == accountId)
            .Sum(t => t.Value);

        public double GetTotalDebit(long accountId) => _dbset
            .Where(t => t.DebitAccountId == accountId)
            .Sum(t => t.Value);

        public IQueryable<Transfer> FindByPeriod(string dini, string dfin)
        {
            DateTime startDate;
            DateTime endDate;

            if (dini != "" && dfin != "" &&
                DateTime.TryParseExact(dini, "dd-MM-yyyy", null, DateTimeStyles.None, out startDate) &&
                DateTime.TryParseExact(dfin + " 23:59:59", "dd-MM-yyyy HH:mm:ss", null, DateTimeStyles.None, out endDate))
            {
                return _dbset
                    .Include("DebitAccount")
                    .Include("CreditAccount")
                    .Where(t =>
                        t.User.Equals(User.LoggedUser) &&
                        t.Date >= startDate &&
                        t.Date <= endDate
                     );
            }
            else
            {
                return FindAll();
            }
        }
    }
}
