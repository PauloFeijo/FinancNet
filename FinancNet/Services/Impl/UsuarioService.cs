using FinancNet.Models;
using FinancNet.Repositories;

namespace FinancNet.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            this.repo = repo;   
        }

        public Usuario Create(Usuario usuario)
        {
            return repo.Create(usuario);
        }

        public object FindByLogin(Usuario usuario)
        {
            bool autorizado = false;

            if (usuario == null || string.IsNullOrWhiteSpace(usuario.login)) return null;

            var usuarioBase = repo.FindByLogin(usuario.login);

            autorizado = usuarioBase != null && usuarioBase.login == usuario.login && 
                usuarioBase.senha == usuario.senha;

            if (!autorizado) return null;

            return usuarioBase;
        }
    }
}
