using FinancNet.Models;
using FinancNet.Repositories.Base.Impl;
using FinancNet.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace FinancNet.Repositories.Impl
{
    public class LancamentoRepository : RepositoryBase<Lancamento>, ILancamentoRepository
    {
        public LancamentoRepository(Contexto ctx) : base(ctx) { }

        private double GetTotalReceitasDespesas(long contaId, string tipo) => 
            _dbset
            .Where(l => l.ContaId == contaId && l.Tipo.ToUpper() == tipo)
            .Sum(l => l.Valor);

        public override IQueryable<Lancamento> FindAll() => 
            _dbset
            .Include("Conta")
            .Include("Categoria")
            .Where(l => l.Usuario.Equals(Usuario.Logado));

        public double GetTotalDespesas(long contaId) => GetTotalReceitasDespesas(contaId, "DESPESA");

        public double GetTotalReceitas(long contaId) => GetTotalReceitasDespesas(contaId, "RECEITA");

        public IQueryable<Lancamento> FindByPeriodo(string dini, string dfin)
        {
            DateTime dataInicial;
            DateTime dataFinal;

            if (dini != "" && dfin != "" &&
                DateTime.TryParseExact(dini, "dd-MM-yyyy", null, DateTimeStyles.None, out dataInicial) &&
                DateTime.TryParseExact(dfin + " 23:59:59", "dd-MM-yyyy HH:mm:ss", null, DateTimeStyles.None, out dataFinal))
            {
                return _dbset
                    .Include("Conta")
                    .Include("Categoria")
                    .Where(l => 
                        l.Usuario.Equals(Usuario.Logado) && 
                        l.Data >= dataInicial && 
                        l.Data <= dataFinal
                     );
            } else
            {
                return FindAll();
            }
        }
    }
}
