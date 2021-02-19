using FinancNet.Models;

namespace FinancNet.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario Create(Usuario usuario);
        Usuario FindByLogin(string login);
    }
}
