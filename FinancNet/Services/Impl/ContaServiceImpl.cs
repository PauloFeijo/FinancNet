using FinancNet.Models;
using FinancNet.Repositories;
using System.Collections.Generic;

namespace FinancNet.Services.Impl
{
    public class ContaServiceImpl : IContaService
    {
        private IRepository<Conta> repo;

        public ContaServiceImpl(IRepository<Conta> repo)
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
