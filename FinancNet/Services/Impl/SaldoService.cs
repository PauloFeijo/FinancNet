using FinancNet.Models;
using FinancNet.Repositories;
using FinancNet.Services.Base;

namespace FinancNet.Services.Impl
{
    public class SaldoService : ISaldoService
    {
        private readonly ILancamentoRepository _lancRepo;
        private readonly ITransferenciaRepository _transfRepo;
        private readonly IServiceBase<Conta> _contaServ;

        public SaldoService(ILancamentoRepository lancRepo, ITransferenciaRepository transfRepo, 
            IServiceBase<Conta> contaServ)
        {
            _lancRepo = lancRepo;
            _transfRepo = transfRepo;
            _contaServ = contaServ;
        }

        public void ProcessarSaldoConta(long contaId)
        {
            Conta conta = _contaServ.FindById(contaId);
            if (conta == null)
            {
                return;
            }
            double receitas = _lancRepo.GetTotalReceitas(contaId) + _transfRepo.GetTotalCreditos(contaId);
            double despesas = _lancRepo.GetTotalDespesas(contaId) + _transfRepo.GetTotalDebitos(contaId);

            conta.Saldo = receitas - despesas;

            _contaServ.Update(conta);
        }
    }
}
