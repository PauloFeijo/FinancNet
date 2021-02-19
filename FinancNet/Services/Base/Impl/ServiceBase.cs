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
            return _repo.Create(item);
        }

        public virtual void Delete(long id) => _repo.Delete(id);

        public IQueryable<T> FindAll() => 
            _repo.FindAll()
            .Where(t => t.Usuario.Equals(Usuario.Logado));

        public T FindById(long id) => _repo.FindById(id);

        public virtual T Update(T item) => _repo.Update(item);
    }
}
