using FinancNet.Interfaces.Repositories;
using FinancNet.Interfaces.Repositories.Base;
using FinancNet.Interfaces.Services;
using FinancNet.Interfaces.Services.Base;
using FinancNet.Repositories;
using FinancNet.Repositories.Base;
using FinancNet.Repositories.Context;
using FinancNet.Services;
using FinancNet.Services.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancNet.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection ConfigureModules(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureEFContext(configuration);

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped<IEntryService, EntryService>();
            services.AddScoped<IEntryRepository, EntryRepository>();

            services.AddScoped<ITransferService, TransferService>();
            services.AddScoped<ITransferRepository, TransferRepository>();

            services.AddScoped<IBalanceService, BalanceService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;

        }

        private static IServiceCollection ConfigureEFContext(this IServiceCollection services, IConfiguration configuration)
        {
            // PostgreSQL
            //services.AddDbContext<Contexto>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));

            // MySql
            //services.AddDbContext<Context>(options => options.UseMySQL(configuration.GetConnectionString("MySql")));

            // SqlServer
            services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            return services;
        }
    }
}
