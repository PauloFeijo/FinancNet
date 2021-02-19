using FinancNet.Models;
using FinancNet.Repositories;
using FinancNet.Services.Base;
using FinancNet.Services.Base.Impl;
using System.Linq;

namespace FinancNet.Services.Impl
{
    public class LancamentoService : ServiceBase<Lancamento>, ILancamentoService
    {
        private readonly ILancamentoRepository _repo;
        private readonly IServiceBase<Categoria> _servCateg;
        private readonly ISaldoService _servSaldo;

        public LancamentoService(ILancamentoRepository repo, IServiceBase<Categoria> servCateg,
            ISaldoService servSaldo) : base(repo)
        {
            _repo = repo;
            _servCateg = servCateg;
            _servSaldo = servSaldo;
        }

        public override Lancamento Create(Lancamento item)
        {
            SetTipo(item);
            Lancamento lanc = base.Create(item);
            _servSaldo.ProcessarSaldoConta(item.ContaId);
            return lanc;
        }

        public override Lancamento Update(Lancamento item)
        {
            long oldContaId = FindById(item.Id).ContaId;

            SetTipo(item);
            Lancamento lanc = base.Update(item);

            if (item.ContaId != oldContaId)
            {
                _servSaldo.ProcessarSaldoConta(oldContaId);
            }
            _servSaldo.ProcessarSaldoConta(item.ContaId);

            return lanc;
        }

        public override void Delete(long id)
        {
            long contaId = FindById(id).ContaId;
            base.Delete(id);
            _servSaldo.ProcessarSaldoConta(contaId);
        }

        public IQueryable<Lancamento> FindByPeriodo(string dini, string dfin) => 
            _repo.FindByPeriodo(dini, dfin);

        private void SetTipo(Lancamento item)
        {
            Categoria cat = _servCateg.FindById(item.CategoriaId);
            if (cat != null)
            {
                item.Tipo = cat.Tipo;
            }
        }
    }
}
