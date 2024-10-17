using FinancNetWeb.Models.Dtos;
using FinancNetWeb.Services.Api.Base;

namespace FinancNetWeb.Services.Api
{
    public class AccountService : ServiceBase<AccountDto>, IAccountService
    {
        public AccountService(IHttpClientFactory httpClientFactory, ILogger<ServiceBase<AccountDto>> logger) :
            base(httpClientFactory, logger, "/account/", "carteira")
        {
        }
    }
}
