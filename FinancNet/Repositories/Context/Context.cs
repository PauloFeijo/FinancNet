using FinancNet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace FinancNet.Repositories.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Account> Account { get; set; }
        public DbSet<Category> Category { get; set; }
        public new DbSet<Entry> Entry { get; set; }
        public DbSet<Transfer> Transfer { get; set; }
        public DbSet<User> User { get; set; }

        public static readonly LoggerFactory logger = new LoggerFactory(new[] { new DebugLoggerProvider() });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(logger);
        }
    }
}
