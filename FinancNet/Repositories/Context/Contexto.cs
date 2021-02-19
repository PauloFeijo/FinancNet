using FinancNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace FinancNet.Repositories.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Conta> conta { get; set; }
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Lancamento> lancamento { get; set; }
        public DbSet<Transferencia> transferencia { get; set; }
        public DbSet<Usuario> usuario { get; set; }

        public static readonly LoggerFactory _myLoggerFactory = 
            new LoggerFactory(new[] { new DebugLoggerProvider() });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }
    }
}
