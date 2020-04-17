using FinancNet.Models;
using FinancNet.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancNet.Repositories.Impl
{
    public class CategoriaRepositoryImpl : ICategoriaRepository
    {
        private Contexto ctx;

        public CategoriaRepositoryImpl(Contexto ctx)
        {
            this.ctx = ctx;
        }

        public Categoria Create(Categoria categoria)
        {
            try
            {
                ctx.Add(categoria);
                ctx.SaveChanges();
                return categoria;
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
                Categoria categoriaDb = FindById(id);
                if (categoriaDb == null) return;

                ctx.categoria.Remove(categoriaDb);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Categoria> FindAll()
        {
            return ctx.categoria.ToList();
        }

        public Categoria FindById(long id)
        {
            return ctx.categoria.SingleOrDefault(p => p.id.Equals(id));
        }

        public Categoria Update(Categoria categoria)
        {
            try
            {
                Categoria categoriaDb = FindById(categoria.id);
                if (categoriaDb == null) return null;

                ctx.Entry(categoriaDb).CurrentValues.SetValues(categoria);
                ctx.SaveChanges();
                return categoriaDb;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
