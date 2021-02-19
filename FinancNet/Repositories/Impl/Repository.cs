using FinancNet.Models;
using FinancNet.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinancNet.Repositories.Impl
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected Contexto ctx;
        protected DbSet<T> dbset;

        public Repository(Contexto ctx)
        {
            this.ctx = ctx;
            dbset = ctx.Set<T>();
        }

        public T Create(T item)
        {
            item.usuario = Usuario.logado;
            dbset.Add(item);
            ctx.SaveChanges();
            return item;
        }

        public void Delete(long id)
        {
            T itemDb = FindById(id);
            if (itemDb == null) return;

            if (itemDb.usuario != Usuario.logado) return;

            dbset.Remove(itemDb);
            ctx.SaveChanges();
        }

        public virtual IQueryable<T> FindAll()
        {
            return dbset
                .Where(t => t.usuario.Equals(Usuario.logado));
        }

        public T FindById(long id)
        {
            return dbset.SingleOrDefault(
                p => p.id.Equals(id) && 
                p.usuario.Equals(Usuario.logado));
        }

        public T Update(T item)
        {
            T itemDb = FindById(item.id);
            if (itemDb == null) return null;

            ctx.Entry(itemDb).CurrentValues.SetValues(item);

            itemDb.usuario = Usuario.logado;

            ctx.SaveChanges();
            return itemDb;
        }
    }
}
