using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancNet.Models;
using FinancNet.Models.Context;

namespace FinancNet.Services.Impl
{
    public class ContaServiceImpl : IContaService
    {
        private PostgreSqlContext _context;

        public ContaServiceImpl(PostgreSqlContext context)
        {
            _context = context;
        }

        public Conta Create(Conta conta)
        {
            try
            {
                conta.id = 0;
                conta.saldo = 0;
                _context.Add(conta);
                _context.SaveChanges();
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
                Conta _conta = FindById(id);
                if (_conta == null) return;

                _context.conta.Remove(_conta);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Conta> FindAll()
        {
            return _context.conta.ToList();
        }

        public Conta FindById(long id)
        {
            return _context.conta.SingleOrDefault(p => p.id.Equals(id));
        }

        public Conta Update(Conta conta)
        {
            try
            {
                Conta _conta = FindById(conta.id);
                if (_conta == null) return null;

                _context.Entry(_conta).CurrentValues.SetValues(conta);
                _context.SaveChanges();
                return conta;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
