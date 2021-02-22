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
            return FindByLogin((LoginDTO) usuario);
        }

        public object FindByLogin(LoginDTO login)
        {
            bool autorizado = false;

            if (login == null || string.IsNullOrWhiteSpace(login.Login)) return null;

            var usuarioBase = _repo.FindByLogin(login.Login);

            autorizado = usuarioBase != null && usuarioBase.Login == login.Login && 
                usuarioBase.Senha == login.Senha;

            if (!autorizado) return NaoAutorizado();

            ClaimsIdentity identity = new ClaimsIdentity(

                new System.Security.Principal.GenericIdentity(login.Login, "Login"),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, login.Login)
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
