using FinancNet.Models;

namespace FinancNet.Services
{
    public interface IUsuarioService
    {
        Usuario Create(Usuario usuario);
        object FindByLogin(Usuario usuario);
    }
}
