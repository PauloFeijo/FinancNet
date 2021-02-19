using FinancNet.Models;
using FinancNet.Models.Base;
using FinancNet.Repositories.Base;
using System.Linq;

namespace FinancNet.Services.Base.Impl
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        private readonly IRepositoryBase<T> _repo;

        public ServiceBase(IRepositoryBase<T> repo)
        {
            _repo = repo;
        }

        public virtual T Create(T item)
        {
            item.Id = 0;
            item.Usuario = Usuario.Logado;
            return _repo.Create(item);
        }

        public virtual void Delete(long id)
        {
            T item = _repo.FindById(id);

            if (item == null) return;

            if (item.Usuario != Usuario.Logado) return;

            _repo.Delete(item);
        }

        public IQueryable<T> FindAll() => 
            _repo.FindAll()
            .Where(t => t.Usuario.Equals(Usuario.Logado));

        public T FindById(long id)
        {
            var item = _repo.FindById(id);

            if (item.Usuario != Usuario.Logado) return null;

            return item;
        }

        public virtual T Update(T item)
        {
            item.Usuario = Usuario.Logado;
            return _repo.Update(item);
        }
    }
}
