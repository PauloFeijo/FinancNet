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
        private Contexto ctx;
        private DbSet<T> dataset;

        public Repository(Contexto ctx)
        {
            this.ctx = ctx;
            dataset = ctx.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
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

                dataset.Remove(itemDb);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.id.Equals(id));
        }

        public T Update(T item)
        {
            try
            {
                T itemDb = FindById(item.id);
                if (itemDb == null) return null;

                ctx.Entry(itemDb).CurrentValues.SetValues(itemDb);
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
