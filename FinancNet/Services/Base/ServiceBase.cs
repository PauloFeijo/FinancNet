using FinancNet.Entities;
using FinancNet.Entities.Base;
using FinancNet.Interfaces.Repositories.Base;
using FinancNet.Interfaces.Services.Base;
using System.Linq;

namespace FinancNet.Services.Base
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
            item.User = User.LoggedUser;
            return _repo.Create(item);
        }

        public virtual void Delete(long id)
        {
            T item = _repo.FindById(id);

            if (item == null) return;

            if (item.User != User.LoggedUser) return;

            _repo.Delete(item);
        }

        public IQueryable<T> FindAll() =>
            _repo.FindAll()
            .Where(t => t.User.Equals(User.LoggedUser));

        public T FindById(long id)
        {
            var item = _repo.FindById(id);

            if (item.User != User.LoggedUser) return null;

            return item;
        }

        public virtual T Update(T item)
        {
            item.User = User.LoggedUser;
            return _repo.Update(item);
        }
    }
}
