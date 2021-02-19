using FinancNet.Models;
using FinancNet.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancNet.Services.Impl
{
    public class LancamentoService : Service<Lancamento>, ILancamentoService
    {
        private ILancamentoRepository repo;
        private IService<Categoria> servCateg;
        private ISaldoService servSaldo;

        private void SetTipo(Lancamento item)
        {
            Categoria cat = servCateg.FindById(item.categoriaId);
            if (cat != null)
            {
                item.tipo = cat.tipo;
            }
        }

        public LancamentoService(ILancamentoRepository repo, IService<Categoria> servCateg,
            ISaldoService servSaldo) : base(repo)
        {
            this.repo = repo;
            this.servCateg = servCateg;
            this.servSaldo = servSaldo;
        }

        public override Lancamento Create(Lancamento item)
        {
            SetTipo(item);
            Lancamento lanc = base.Create(item);
            servSaldo.ProcessarSaldoConta(item.contaId);
            return lanc;
        }

        public override Lancamento Update(Lancamento item)
        {
            long oldContaId = FindById(item.id).contaId;

            SetTipo(item);
            Lancamento lanc = base.Update(item);

            if (item.contaId != oldContaId)
            {
                servSaldo.ProcessarSaldoConta(oldContaId);
            }
            servSaldo.ProcessarSaldoConta(item.contaId);

            return lanc;
        }

        public override void Delete(long id)
        {
            long contaId = FindById(id).contaId;
            base.Delete(id);
            servSaldo.ProcessarSaldoConta(contaId);
        }

        public IQueryable<Lancamento> FindByPeriodo(string dini, string dfin)
        {
            return repo.FindByPeriodo(dini, dfin);
        }
    }
}
