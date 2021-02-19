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
            item.Usuario = Usuario.Logado;
            _dbset.Add(item);
            _ctx.SaveChanges();
            return item;
        }

        public void Delete(long id)
        {
            T itemDb = FindById(id);
            if (itemDb == null) return;

            if (itemDb.Usuario != Usuario.Logado) return;

            _dbset.Remove(itemDb);
            _ctx.SaveChanges();
        }

        public virtual IQueryable<T> FindAll() => _dbset
            .Where(t => t.Usuario.Equals(Usuario.Logado));

        public T FindById(long id)
        {
            return _dbset.SingleOrDefault(
                p => p.Id.Equals(id) && 
                p.Usuario.Equals(Usuario.Logado));
        }

        public T Update(T item)
        {
            T itemDb = FindById(item.Id);
            if (itemDb == null) return null;

            _ctx.Entry(itemDb).CurrentValues.SetValues(item);

            itemDb.Usuario = Usuario.Logado;

            _ctx.SaveChanges();
            return itemDb;
        }
    }
}
