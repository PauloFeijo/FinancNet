using FinancNet.Models;
using FinancNet.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FinancNet.Repositories.Impl
{
    public class LancamentoRepository : Repository<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(Contexto ctx) : base(ctx) {}

        private double GetTotalReceitasDespesas(long contaId, string tipo)
        {
            return dbset
                .Where(l => l.contaId == contaId && l.tipo.ToUpper() == tipo)
                .Sum(l => l.valor);
        }

        public override IQueryable<Lancamento> FindAll()
        {
            return dbset
                .Include("conta")
                .Include("categoria")
                .Where(l => l.usuario.Equals(Usuario.logado));
        }

        public double GetTotalDespesas(long contaId)
        {
            return GetTotalReceitasDespesas(contaId, "DESPESA");
        }

        public double GetTotalReceitas(long contaId)
        {
            return GetTotalReceitasDespesas(contaId, "RECEITA");
        }

        public IQueryable<Lancamento> FindByPeriodo(string dini, string dfin)
        {
            DateTime dataInicial;
            DateTime dataFinal;

            if (dini != "" && dfin != "" &&
                DateTime.TryParseExact(dini, "dd-MM-yyyy", null, DateTimeStyles.None, out dataInicial) &&
                DateTime.TryParseExact(dfin + " 23:59:59", "dd-MM-yyyy HH:mm:ss", null, DateTimeStyles.None, out dataFinal))
            {
                return dbset
                    .Include("conta")
                    .Include("categoria")
                    .Where(l => 
                        l.usuario.Equals(Usuario.logado) && 
                        l.data >= dataInicial && 
                        l.data <= dataFinal
                     );
            } else
            {
                return FindAll();
            }
        }
    }
}
