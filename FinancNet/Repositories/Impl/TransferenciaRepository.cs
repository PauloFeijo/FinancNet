using FinancNet.Models;
using FinancNet.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FinancNet.Repositories.Impl
{
    public class TransferenciaRepository : Repository<Transferencia>, ITransferenciaRepository
    {
        public TransferenciaRepository(Contexto ctx) : base(ctx) {}


        public override IQueryable<Transferencia> FindAll()
        {
            return dbset
                .Include("contaDebito")
                .Include("contaCredito")
                .Where(t => t.usuario.Equals(Usuario.logado));
        }

        public double GetTotalCreditos(long contaId)
        {
            return dbset
                .Where(t => t.contaCreditoId == contaId)
                .Sum(t => t.valor);
        }

        public double GetTotalDebitos(long contaId)
        {
            return dbset
                .Where(t => t.contaDebitoId == contaId)
                .Sum(t => t.valor);
        }

        public IQueryable<Transferencia> FindByPeriodo(string dini, string dfin)
        {
            DateTime dataInicial;
            DateTime dataFinal;

            if (dini != "" && dfin != "" &&
                DateTime.TryParseExact(dini, "dd-MM-yyyy", null, DateTimeStyles.None, out dataInicial) &&
                DateTime.TryParseExact(dfin + " 23:59:59", "dd-MM-yyyy HH:mm:ss", null, DateTimeStyles.None, out dataFinal))
            {
                return dbset
                    .Include("contaDebito")
                    .Include("contaCredito")
                    .Where(t => 
                        t.usuario.Equals(Usuario.logado) &&
                        t.data >= dataInicial && 
                        t.data <= dataFinal
                     );
            }
            else
            {
                return FindAll();
            }
        }
    }
}
