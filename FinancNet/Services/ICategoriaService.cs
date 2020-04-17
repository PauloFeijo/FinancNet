using FinancNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancNet.Services
{
    public interface ICategoriaService
    {
        Categoria Create(Categoria categoria);
        Categoria FindById(long id);
        Categoria Update(Categoria categoria);
        List<Categoria> FindAll();
        void Delete(long id);
    }
}
