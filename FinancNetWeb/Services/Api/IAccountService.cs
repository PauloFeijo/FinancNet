using FinancNetWeb.Models.Dtos;

namespace FinancNetWeb.Services.Api
{
    public interface IAccountService
    {
        Task<List<AccountDto>> GetAll();
        Task<AccountDto> Get(long id);
        Task<AccountDto> Create(AccountDto accountDto);
        Task<AccountDto> Update(long id, AccountDto accountDto);
        Task<bool> Delete(long id);
    }
}
