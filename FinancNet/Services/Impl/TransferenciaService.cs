using FinancNet.Models;
using FinancNet.Repositories;
using System;

namespace FinancNet.Services.Impl
{
    public class TransferenciaService : Service<Transferencia>, ITransferenciaService
    {
        private ITransferenciaRepository repo;

        public TransferenciaService(ITransferenciaRepository repo) : base(repo)
        {
            this.repo = repo;
        }
    }
}
