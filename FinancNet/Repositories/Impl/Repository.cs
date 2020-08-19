using FinancNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using FinancNet.Repositories.Context;

namespace FinancNet.Repositories.Impl
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected Contexto ctx;
        protected DbSet<T> dataset;

        public Repository(Contexto ctx)
        {
            this.ctx = ctx;
            dataset = ctx.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                item.usuario = Usuario.logado;
                dataset.Add(item);
                ctx.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(long id)
        {
            try
            {
                T itemDb = FindById(id);
                if (itemDb == null) return;

                if (itemDb.usuario != Usuario.logado) return;

                dataset.Remove(itemDb);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual List<T> FindAll()
        {
            return dataset
                .Where(t => t.usuario.Equals(Usuario.logado))
                .ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(
                p => p.id.Equals(id) && 
                p.usuario.Equals(Usuario.logado));
        }

        public T Update(T item)
        {
            try
            {
                T itemDb = FindById(item.id);
                if (itemDb == null) return null;

                ctx.Entry(itemDb).CurrentValues.SetValues(item);

                itemDb.usuario = Usuario.logado;

                ctx.SaveChanges();
                return itemDb;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
