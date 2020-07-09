using FinancNet.Models;
using FinancNet.Repositories;
using System;
using System.Collections.Generic;

namespace FinancNet.Services.Impl
{
    public class TransferenciaService : Service<Transferencia>, ITransferenciaService
    {
        private ITransferenciaRepository repo;
        private ISaldoService servSaldo;

        public TransferenciaService(ITransferenciaRepository repo, ISaldoService servSaldo) : base(repo)
        {
            this.repo = repo;
            this.servSaldo = servSaldo;
        }

        public override Transferencia Create(Transferencia item)
        {
            Transferencia transf = base.Create(item);
            servSaldo.ProcessarSaldoConta(item.contaDebitoId);
            servSaldo.ProcessarSaldoConta(item.contaCreditoId);
            return transf;
        }

        public override Transferencia Update(Transferencia item)
        {
            Transferencia transf = FindById(item.id);

            if (transf == null)
            {
                return null;
            }

            long oldContaDebitoId = transf.contaDebitoId;
            long oldContaCreditoId = transf.contaCreditoId;

            transf = base.Update(item);

            if (item.contaDebitoId != oldContaDebitoId)
            {
                servSaldo.ProcessarSaldoConta(oldContaDebitoId);
            }
            servSaldo.ProcessarSaldoConta(item.contaDebitoId);

            if (item.contaCreditoId != oldContaCreditoId)
            {
                servSaldo.ProcessarSaldoConta(oldContaCreditoId);
            }
            servSaldo.ProcessarSaldoConta(item.contaCreditoId);

            return transf;
        }

        public override void Delete(long id)
        {
            Transferencia transf = FindById(id);

            if (transf == null)
            {
                return;
            }

            long contaDebitoId = transf.contaDebitoId;
            long contaCreditoId = transf.contaCreditoId;

            base.Delete(id);

            servSaldo.ProcessarSaldoConta(contaDebitoId);
            servSaldo.ProcessarSaldoConta(contaCreditoId);
        }

        public List<Transferencia> FindByPeriodo(string dini, string dfin)
        {
            return repo.FindByPeriodo(dini, dfin);
        }
    }
}
