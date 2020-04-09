using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancNet.Models;

namespace FinancNet.Services.Impl
{
    public class ContaServiceImpl : IContaService
    {
        public Conta Create(Conta conta)
        {
            return conta;
        }

        public void Delete(long id)
        {
            
        }

        public List<Conta> FindAll()
        {
            List<Conta> contas = new List<Conta>();

            contas.Add(new Conta(1, "Conta 1", "1", 0.0));
            contas.Add(new Conta(2, "Conta 2", "2", 0.0));
            contas.Add(new Conta(3, "Conta 3", "3", 0.0));
            contas.Add(new Conta(4, "Conta 4", "4", 0.0));

            return contas;
        }

        public Conta FindById(long id)
        {
            return new Conta(id, "Nova Conta", "", 0.0);
        }

        public Conta Update(Conta conta)
        {
            return conta;
        }
    }
}
