using FinancNet.Models;
using FinancNet.Repositories;
using System.Collections.Generic;

namespace FinancNet.Services.Impl
{
    public class CategoriaServiceImpl : ICategoriaService
    {
        private IRepository<Categoria> repo;

        public CategoriaServiceImpl(IRepository<Categoria> repo)
        {
            this.repo = repo;
        }

        public Categoria Create(Categoria categoria)
        {
            categoria.id = 0;
            return repo.Create(categoria);
        }

        public void Delete(long id)
        {
            repo.Delete(id);
        }

        public List<Categoria> FindAll()
        {
            return repo.FindAll();
        }

        public Categoria FindById(long id)
        {
            return repo.FindById(id);
        }

        public Categoria Update(Categoria categoria)
        {
            return repo.Update(categoria);
        }
    }
}
