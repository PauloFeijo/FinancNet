using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancNet.Models;
using FinancNet.Models.Context;
using FinancNet.Repositories;

namespace FinancNet.Services.Impl
{
    public class ContaServiceImpl : IContaService
    {
        private IContaRepository repo;

        public ContaServiceImpl(IContaRepository repo)
        {
            this.repo = repo;
        }

        public Conta Create(Conta conta)
        {
            conta.id = 0;
            conta.saldo = 0;
            return repo.Create(conta);
        }

        public void Delete(long id)
        {
            repo.Delete(id);
        }

        public List<Conta> FindAll()
        {
            return repo.FindAll();
        }

        public Conta FindById(long id)
        {
            return repo.FindById(id);
        }

        public Conta Update(Conta conta)
        {
            return repo.Update(conta);
        }
    }
}
