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
        private readonly IUsuarioRepository _repo;
        private readonly SigningConfigurations _signConfig;
        private readonly TokenConfiguration _tokenConfig;

        public UsuarioService(IUsuarioRepository repo, SigningConfigurations signConfig,
            TokenConfiguration tokenConfig)
        {
            _repo = repo;   
            _signConfig = signConfig;
            _tokenConfig = tokenConfig;
        }

        public object Create(Usuario usuario)
        {
            _repo.Create(usuario);
            return FindByLogin(usuario);
        }

        public object FindByLogin(Usuario usuario)
        {
            bool autorizado = false;

            if (usuario == null || string.IsNullOrWhiteSpace(usuario.Login)) return null;

            var usuarioBase = _repo.FindByLogin(usuario.Login);

            autorizado = usuarioBase != null && usuarioBase.Login == usuario.Login && 
                usuarioBase.Senha == usuario.Senha;

            if (!autorizado) return NaoAutorizado();

            ClaimsIdentity identity = new ClaimsIdentity(

                new System.Security.Principal.GenericIdentity(usuario.Login, "Login"),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Login)
                }
            );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(_tokenConfig.Seconds);

            string token = CriarToken(identity, dataCriacao, dataExpiracao, new JwtSecurityTokenHandler());

            return Autorizado(dataCriacao, dataExpiracao, token);
        }

        private string CriarToken(ClaimsIdentity identity, DateTime dataCriacao, DateTime dataExpiracao, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfig.Issuer,
                Audience = _tokenConfig.Audience,
                SigningCredentials = _signConfig.Credentials,
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
