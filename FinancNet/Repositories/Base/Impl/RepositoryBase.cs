using FinancNet.Models;
using FinancNet.Models.Base;
using FinancNet.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinancNet.Repositories.Base.Impl
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly Contexto _ctx;
        protected readonly DbSet<T> _dbset;

        public RepositoryBase(Contexto ctx)
        {
            _ctx = ctx;
            _dbset = ctx.Set<T>();
        }

        public T Create(T item)
        {
            _dbset.Add(item);
            _ctx.SaveChanges();
            return item;
        }

        public void Delete(T item)
        {
            _dbset.Remove(item);
            _ctx.SaveChanges();
        }

        public virtual IQueryable<T> FindAll() => _dbset;

        public T FindById(long id)
        {
            return _dbset.SingleOrDefault(
                p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            T itemDb = FindById(item.Id);
            if (itemDb == null) return null;

            _ctx.Entry(itemDb).CurrentValues.SetValues(item);

            _ctx.SaveChanges();
            return itemDb;
        }
    }
}
