using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancNet.Models;
using FinancNet.Models.Context;

namespace FinancNet.Repositories.Impl
{
    public class ContaRepositoryImpl : IContaRepository
    {
        private PostgreSqlContext ctx;

        public ContaRepositoryImpl(PostgreSqlContext ctx)
        {
            this.ctx = ctx;
        }

        public Conta Create(Conta conta)
        {
            try
            {
                ctx.Add(conta);
                ctx.SaveChanges();
                return conta;
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
                Conta contaDb = FindById(id);
                if (contaDb == null) return;

                ctx.conta.Remove(contaDb);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Conta> FindAll()
        {
            return ctx.conta.ToList();
        }

        public Conta FindById(long id)
        {
            return ctx.conta.SingleOrDefault(p => p.id.Equals(id));
        }

        public Conta Update(Conta conta)
        {
            try
            {
                Conta contaDb = FindById(conta.id);
                if (contaDb == null) return null;

                ctx.Entry(contaDb).CurrentValues.SetValues(conta);
                ctx.SaveChanges();
                return contaDb;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
