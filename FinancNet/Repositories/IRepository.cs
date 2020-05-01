using FinancNet.Models;
using System.Collections.Generic;

namespace FinancNet.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        T Create(T item);
        T FindById(long id);
        T Update(T item);
        List<T> FindAll();
        void Delete(long id);
    }
}
