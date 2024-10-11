using FinancNet.Dtos;
using FinancNet.Entities;
using FinancNet.Interfaces.Repositories;
using FinancNet.Interfaces.Services;
using FinancNet.Security.Config;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FinancNet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly SigningConfigurations _signConfig;
        private readonly TokenConfiguration _tokenConfig;

        public UserService(IUserRepository repo, SigningConfigurations signConfig, TokenConfiguration tokenConfig)
        {
            _repo = repo;
            _signConfig = signConfig;
            _tokenConfig = tokenConfig;
        }

        public object Create(User user)
        {
            _repo.Create(user);
            return FindByLogin((LoginDTO)user);
        }

        public object FindByLogin(LoginDTO login)
        {
            bool authorized = false;

            if (login == null || string.IsNullOrWhiteSpace(login.Login)) return null;

            var userDb = _repo.FindByLogin(login.Login);

            authorized = userDb != null
                && userDb.Login == login.Login
                && userDb.Password == login.Password;

            if (!authorized) return Unauthorized();

            ClaimsIdentity identity = new ClaimsIdentity(

                new System.Security.Principal.GenericIdentity(login.Login, "Login"),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, login.Login)
                }
            );

            DateTime creationDate = DateTime.UtcNow;
            DateTime expirationDate = creationDate + TimeSpan.FromSeconds(_tokenConfig.Seconds);

            string token = CreateToken(identity, creationDate, expirationDate, new JwtSecurityTokenHandler());

            return Authorized(creationDate, expirationDate, token);
        }

        private string CreateToken(ClaimsIdentity identity, DateTime creationDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfig.Issuer,
                Audience = _tokenConfig.Audience,
                SigningCredentials = _signConfig.Credentials,
                Subject = identity,
                NotBefore = creationDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object Unauthorized()
        {
            return new
            {
                autenticated = false,
                message = "Falha de autenticação"
            };
        }

        private object Authorized(DateTime createdDate, DateTime expirationDate, string token)
        {
            return new
            {
                autenticated = true,
                created = createdDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}
