using FinancNet.Entities.Base;
using System.Linq;

namespace FinancNet.Interfaces.Services.Base
{
    public interface IServiceBase<T> where T : EntityBase
    {
        T Create(T item);
        T FindById(long id);
        T Update(T item);
        IQueryable<T> FindAll();
        void Delete(long id);
    }
}
