using FinancNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancNet.Services
{
    public interface IContaService
    {
        Conta Create(Conta conta);
        Conta FindById(long id);
        Conta Update(Conta conta);
        List<Conta> FindAll();
        void Delete(long id);
    }
}
