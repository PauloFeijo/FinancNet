using FinancNet.Models;
using FinancNet.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace FinancNet.Repositories.Base
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        T Create(T item);
        T FindById(long id);
        T Update(T item);
        IQueryable<T> FindAll();
        void Delete(long id);
    }
}
