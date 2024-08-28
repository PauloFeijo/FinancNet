using FinancNet.Entities.Base;
using System.Linq;

namespace FinancNet.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        T Create(T item);
        T FindById(long id);
        T Update(T item);
        IQueryable<T> FindAll();
        void Delete(T item);
    }
}
