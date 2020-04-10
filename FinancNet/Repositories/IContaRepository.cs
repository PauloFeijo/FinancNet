using FinancNet.Models;
using System.Collections.Generic;

namespace FinancNet.Repositories
{
    public interface IContaRepository
    {
        Conta Create(Conta conta);
        Conta FindById(long id);
        Conta Update(Conta conta);
        List<Conta> FindAll();
        void Delete(long id);
    }
}
