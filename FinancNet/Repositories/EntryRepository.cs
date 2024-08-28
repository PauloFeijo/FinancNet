using FinancNet.Entities;
using FinancNet.Enums;
using FinancNet.Interfaces.Repositories;
using FinancNet.Repositories.Base;
using FinancNet.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace FinancNet.Repositories
{
    public class EntryRepository : RepositoryBase<Entry>, IEntryRepository
    {
        public EntryRepository(Context.Context ctx) : base(ctx) { }

        private double GetTotalRevenueExpense(long accountId, EntryType type) =>
            _dbset
            .Where(l => l.AccountId == accountId && l.Type == type)
            .Sum(l => l.Value);

        public override IQueryable<Entry> FindAll() => _dbset
            .Include("Account")
            .Include("Category")
            .Where(l => l.User.Equals(User.LoggedUser));

        public double GetTotalExpense(long accountId) => GetTotalRevenueExpense(accountId, EntryType.Expense);

        public double GetTotalRevenue(long accountId) => GetTotalRevenueExpense(accountId, EntryType.Revenue);

        public IQueryable<Entry> FindByPeriod(string dini, string dfin)
        {
            DateTime dataInicial;
            DateTime dataFinal;

            if (dini != "" && dfin != "" &&
                DateTime.TryParseExact(dini, "dd-MM-yyyy", null, DateTimeStyles.None, out dataInicial) &&
                DateTime.TryParseExact(dfin + " 23:59:59", "dd-MM-yyyy HH:mm:ss", null, DateTimeStyles.None, out dataFinal))
            {
                return _dbset
                    .Include("Account")
                    .Include("Category")
                    .Where(l =>
                        l.User.Equals(User.LoggedUser) &&
                        l.Date >= dataInicial &&
                        l.Date <= dataFinal
                     );
            }
            else
            {
                return FindAll();
            }
        }
    }
}
