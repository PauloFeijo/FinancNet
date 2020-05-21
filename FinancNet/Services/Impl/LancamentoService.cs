using FinancNet.Models;
using FinancNet.Repositories;
using System;

namespace FinancNet.Services.Impl
{
    public class LancamentoService : Service<Lancamento>, ILancamentoService
    {
        ILancamentoRepository repo;

        public LancamentoService(ILancamentoRepository repo) : base(repo)
        {
            this.repo = repo;
        }
    }
}
