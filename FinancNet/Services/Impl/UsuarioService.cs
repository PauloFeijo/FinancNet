using FinancNet.Models;
using FinancNet.Repositories;
using FinancNet.Security.Config;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinancNet.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository repo;
        private SigningConfigurations signConfig;
        private TokenConfiguration tokenConfig;

        public UsuarioService(IUsuarioRepository repo, SigningConfigurations signConfig,
            TokenConfiguration tokenConfig)
        {
            this.repo = repo;   
            this.signConfig = signConfig;
            this.tokenConfig = tokenConfig;
        }

        public object Create(Usuario usuario)
        {
            repo.Create(usuario);
            return FindByLogin(usuario);
        }

        public object FindByLogin(Usuario usuario)
        {
            bool autorizado = false;

            if (usuario == null || string.IsNullOrWhiteSpace(usuario.login)) return null;

            var usuarioBase = repo.FindByLogin(usuario.login);

            autorizado = usuarioBase != null && usuarioBase.login == usuario.login && 
                usuarioBase.senha == usuario.senha;

            if (!autorizado) return NaoAutorizado();

            ClaimsIdentity identity = new ClaimsIdentity(

                new System.Security.Principal.GenericIdentity(usuario.login, "Login"),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, usuario.login)
                }
            );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfig.Seconds);

            string token = CriarToken(identity, dataCriacao, dataExpiracao, new JwtSecurityTokenHandler());

            return Autorizado(dataCriacao, dataExpiracao, token);
        }

        private string CriarToken(ClaimsIdentity identity, DateTime dataCriacao, DateTime dataExpiracao, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfig.Issuer,
                Audience = tokenConfig.Audience,
                SigningCredentials = signConfig.Credentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object NaoAutorizado()
        {
            return new
            {
                autenticated = false,
                message = "Falha de autenticação"
            };
        }

        private object Autorizado(DateTime dataCriacao, DateTime dataExpiracao, string token)
        {
            return new
            {
                autenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}
