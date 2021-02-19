using FinancNet.Models;
using FinancNet.Repositories.Context;
using System.Linq;

namespace FinancNet.Repositories.Impl
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _ctx;

        public UsuarioRepository(Contexto ctx)
        {
            this._ctx = ctx;
        }

        public Usuario Create(Usuario usuario)
        {
            _ctx.usuario.Add(usuario);
            _ctx.SaveChanges();
            return usuario;
        }

        public Usuario FindByLogin(string login) => 
            _ctx.usuario.SingleOrDefault(u => u.Login.Equals(login));
    }
}
