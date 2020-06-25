using FinancNet.Models;
using FinancNet.Repositories;
using System;

namespace FinancNet.Services.Impl
{
    public class LancamentoService : Service<Lancamento>, ILancamentoService
    {
        private ILancamentoRepository repo;
        private IService<Categoria> servCateg;
        private IService<Conta> servConta;

        private void SetTipo(Lancamento item)
        {
            Categoria cat = servCateg.FindById(item.categoriaId);
            if (cat != null)
            {
                item.tipo = cat.tipo;
            }
        }

        private void ProcessarSaldoConta(long contaId)
        {
            Conta conta = servConta.FindById(contaId);
            if (conta == null)
            {
                return;
            }

            double receitas = repo.GetTotalReceitas(contaId);
            double despesas = repo.GetTotalDespesas(contaId);

            conta.saldo = receitas - despesas;

            servConta.Update(conta);
        }

        public LancamentoService(ILancamentoRepository repo, IService<Categoria> servCateg, 
            IService<Conta> servConta) : base(repo)
        {
            this.repo = repo;
            this.servCateg = servCateg;
            this.servConta = servConta;
        }

        public override Lancamento Create(Lancamento item)
        {
            SetTipo(item);
            Lancamento lanc = base.Create(item);
            ProcessarSaldoConta(item.contaId);
            return lanc;
        }

        public override Lancamento Update(Lancamento item)
        {
            long oldContaId = FindById(item.id).contaId;

            SetTipo(item);
            Lancamento lanc = base.Update(item);

            if (item.contaId != oldContaId)
            {
                ProcessarSaldoConta(oldContaId);
            }
            ProcessarSaldoConta(item.contaId);

            return lanc;
        }

        public override void Delete(long id)
        {
            long contaId = FindById(id).contaId;
            base.Delete(id);
            ProcessarSaldoConta(contaId);
        }
    }
}
