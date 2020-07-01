using FinancNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancNet.Repositories.Context
{
    public class Contexto : DbContext
    {
        public Contexto() { }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Conta> conta { get; set; }
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Lancamento> lancamento { get; set; }
        public DbSet<Transferencia> transferencia { get; set; }
    }
}
