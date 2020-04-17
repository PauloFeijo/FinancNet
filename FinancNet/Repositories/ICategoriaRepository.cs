using FinancNet.Models;
using System.Collections.Generic;

namespace FinancNet.Repositories
{
    public interface ICategoriaRepository
    {
        Categoria Create(Categoria categoria);
        Categoria FindById(long id);
        Categoria Update(Categoria categoria);
        List<Categoria> FindAll();
        void Delete(long id);
    }
}
