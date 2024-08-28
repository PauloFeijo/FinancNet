using FinancNet.Security.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace FinancNet.Extensions
{
    public static class AuthExtensions
    {
        public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var signConfig = new SigningConfigurations();
            services.AddSingleton(signConfig);

            var tokenConfig = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                configuration.GetSection("TokenConfigurations"))
                .Configure(tokenConfig);

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

            return services;
        }
    }
}
