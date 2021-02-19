using FinancNet.Models;
using FinancNet.Repositories;
using FinancNet.Services.Base.Impl;
using System.Linq;

namespace FinancNet.Services.Impl
{
    public class TransferenciaService : ServiceBase<Transferencia>, ITransferenciaService
    {
        private readonly ITransferenciaRepository _repo;
        private readonly ISaldoService _servSaldo;

        public TransferenciaService(ITransferenciaRepository repo, ISaldoService servSaldo) : base(repo)
        {
            _repo = repo;
            _servSaldo = servSaldo;
        }

        public override Transferencia Create(Transferencia item)
        {
            Transferencia transf = base.Create(item);
            _servSaldo.ProcessarSaldoConta(item.ContaDebitoId);
            _servSaldo.ProcessarSaldoConta(item.ContaCreditoId);
            return transf;
        }

        public override Transferencia Update(Transferencia item)
        {
            Transferencia transf = FindById(item.Id);

            if (transf == null)
            {
                return null;
            }

            long oldContaDebitoId = transf.ContaDebitoId;
            long oldContaCreditoId = transf.ContaCreditoId;

            transf = base.Update(item);

            if (item.ContaDebitoId != oldContaDebitoId)
            {
                _servSaldo.ProcessarSaldoConta(oldContaDebitoId);
            }
            _servSaldo.ProcessarSaldoConta(item.ContaDebitoId);

            if (item.ContaCreditoId != oldContaCreditoId)
            {
                _servSaldo.ProcessarSaldoConta(oldContaCreditoId);
            }
            _servSaldo.ProcessarSaldoConta(item.ContaCreditoId);

            return transf;
        }

        public override void Delete(long id)
        {
            Transferencia transf = FindById(id);

            if (transf == null)
            {
                return;
            }

            long contaDebitoId = transf.ContaDebitoId;
            long contaCreditoId = transf.ContaCreditoId;

            base.Delete(id);

            _servSaldo.ProcessarSaldoConta(contaDebitoId);
            _servSaldo.ProcessarSaldoConta(contaCreditoId);
        }

        public IQueryable<Transferencia> FindByPeriodo(string dini, string dfin)
        {
            return _repo.FindByPeriodo(dini, dfin);
        }
    }
}
