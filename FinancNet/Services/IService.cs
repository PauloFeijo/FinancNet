using FinancNet.Models;
using System.Collections.Generic;

namespace FinancNet.Services
{
    public interface IService<T> where T : Entity
    {
        T Create(T item);
        T FindById(long id);
        T Update(T item);
        List<T> FindAll();
        void Delete(long id);
    }
}
