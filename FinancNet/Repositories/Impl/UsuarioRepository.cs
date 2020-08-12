using FinancNet.Models;
using FinancNet.Repositories.Context;
using System;
using System.Linq;

namespace FinancNet.Repositories.Impl
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected Contexto ctx;

        public UsuarioRepository(Contexto ctx)
        {
            this.ctx = ctx;
        }

        public Usuario Create(Usuario usuario)
        {
            try
            {
                ctx.usuario.Add(usuario);
                ctx.SaveChanges();
                return usuario;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Usuario FindByLogin(string login)
        {
            return ctx.usuario.SingleOrDefault(u => u.login.Equals(login));
        }
    }
}
