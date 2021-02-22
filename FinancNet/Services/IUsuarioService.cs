using FinancNet.Models;

namespace FinancNet.Services
{
    public interface IUsuarioService
    {
        object Create(Usuario usuario);
        object FindByLogin(LoginDTO login);
    }
}
