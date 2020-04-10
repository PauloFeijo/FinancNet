using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancNet.Models.Context
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext() {}

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options) { }

        public DbSet<Conta> conta { get; set; }
    }
}
