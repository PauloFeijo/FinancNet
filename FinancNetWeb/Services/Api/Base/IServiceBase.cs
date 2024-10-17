namespace FinancNetWeb.Services.Api.Base
{
    public interface IServiceBase<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(long id);
        Task<T> Create(T dto);
        Task<T> Update(long id, T dto);
        Task<bool> Delete(long id);
    }
}
