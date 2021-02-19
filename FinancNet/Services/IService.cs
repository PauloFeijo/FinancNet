using FinancNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinancNet.Services
{
    public interface IService<T> where T : Entity
    {
        T Create(T item);
        T FindById(long id);
        T Update(T item);
        IQueryable<T> FindAll();
        void Delete(long id);
    }
}
