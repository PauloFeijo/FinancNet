using FinancNet.Repositories;
using FinancNet.Repositories.Context;
using FinancNet.Repositories.Impl;
using FinancNet.Security.Config;
using FinancNet.Services;
using FinancNet.Services.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace FinancNet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigurarAcessoADados(services);

            ConfigurarAutenticacao(services);

        }

        private void ConfigurarAutenticacao(IServiceCollection services)
        {
            var signConfig = new SigningConfigurations();
            services.AddSingleton(signConfig);

            var tokenConfig = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                Configuration.GetSection("TokenConfigurations")
            ).Configure(tokenConfig);

            services.AddSingleton(tokenConfig);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOptions =>
            {
                var validPrm = bearerOptions.TokenValidationParameters;
                validPrm.IssuerSigningKey = signConfig.Key;
                validPrm.ValidAudience = tokenConfig.Audience;
                validPrm.ValidIssuer = tokenConfig.Issuer;
                validPrm.ValidateIssuerSigningKey = true;
                validPrm.ValidateLifetime = true;
                validPrm.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
        }

        private void ConfigurarAcessoADados(IServiceCollection services)
        {
            // PostgreSQL
            //services.AddDbContext<Contexto>(options => options.UseNpgsql(Configuration["PostgreSqlConnection:ConnectionString"]));

            // MySql
            services.AddDbContext<Contexto>(options => options.UseMySQL(Configuration["MySqlConnection:ConnectionString"]));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));

            services.AddScoped<ILancamentoService, LancamentoService>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();

            services.AddScoped<ITransferenciaService, TransferenciaService>();
            services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();

            services.AddScoped<ISaldoService, SaldoService>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(options => 
                options.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
