using FinancNet.Models;
using System.Collections.Generic;

namespace FinancNet.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario Create(Usuario usuario);
        Usuario FindByLogin(string login);
    }
}
