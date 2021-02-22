using FinancNet.Models;
using FinancNet.Repositories.Base.Impl;
using FinancNet.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace FinancNet.Repositories.Impl
{
    public class TransferenciaRepository : RepositoryBase<Transferencia>, ITransferenciaRepository
    {
        public TransferenciaRepository(Contexto ctx) : base(ctx) { }

        public override IQueryable<Transferencia> FindAll() => _dbset
            .Include("ContaDebito")
            .Include("ContaCredito")
            .Where(t => t.Usuario.Equals(Usuario.Logado));

        public double GetTotalCreditos(long contaId) => _dbset
            .Where(t => t.ContaCreditoId == contaId)
            .Sum(t => t.Valor);

        public double GetTotalDebitos(long contaId) => _dbset
            .Where(t => t.ContaDebitoId == contaId)
            .Sum(t => t.Valor);

        public IQueryable<Transferencia> FindByPeriodo(string dini, string dfin)
        {
            DateTime dataInicial;
            DateTime dataFinal;

            if (dini != "" && dfin != "" &&
                DateTime.TryParseExact(dini, "dd-MM-yyyy", null, DateTimeStyles.None, out dataInicial) &&
                DateTime.TryParseExact(dfin + " 23:59:59", "dd-MM-yyyy HH:mm:ss", null, DateTimeStyles.None, out dataFinal))
            {
                return _dbset
                    .Include("ContaDebito")
                    .Include("ContaCredito")
                    .Where(t => 
                        t.Usuario.Equals(Usuario.Logado) &&
                        t.Data >= dataInicial && 
                        t.Data <= dataFinal
                     );
            }
            else
            {
                return FindAll();
            }
        }
    }
}
