using FinancNet.Models;
using FinancNet.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FinancNet.Services.Impl
{
    public class Service<T> : IService<T> where T : Entity
    {
        private IRepository<T> repo;

        public Service(IRepository<T> repo)
        {
            this.repo = repo;
        }

        public virtual T Create(T item)
        {
            item.id = 0;
            return repo.Create(item);
        }

        public virtual void Delete(long id)
        {
            repo.Delete(id);
        }

        public IQueryable<T> FindAll()
        {
            return repo.FindAll()
                .Where(t => t.usuario.Equals(Usuario.logado));
        }

        public T FindById(long id)
        {
            return repo.FindById(id);
        }

        public virtual T Update(T item)
        {
            return repo.Update(item);
        }
    }
}
