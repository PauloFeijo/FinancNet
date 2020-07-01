using FinancNet.Models;
using FinancNet.Repositories;
using System;

namespace FinancNet.Services.Impl
{
    public class SaldoService : ISaldoService
    {
        private ILancamentoRepository lancRepo;
        private ITransferenciaRepository transfRepo;
        private IService<Conta> contaServ;

        public SaldoService(ILancamentoRepository lancRepo, ITransferenciaRepository transfRepo, 
            IService<Conta> contaServ)
        {
            this.lancRepo = lancRepo;
            this.transfRepo = transfRepo;
            this.contaServ = contaServ;
        }

        public void ProcessarSaldoConta(long contaId)
        {
            Conta conta = contaServ.FindById(contaId);
            if (conta == null)
            {
                return;
            }
            double receitas = lancRepo.GetTotalReceitas(contaId) + transfRepo.GetTotalCreditos(contaId);
            double despesas = lancRepo.GetTotalDespesas(contaId) + transfRepo.GetTotalDebitos(contaId);

            conta.saldo = receitas - despesas;

            contaServ.Update(conta);
        }
    }
}
