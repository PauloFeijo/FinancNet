using FinancNet.Entities;
using FinancNet.Interfaces.Services.Base;

namespace FinancNet.Controllers
{
    public class AccountController : FinancControllerBase<Account>
    {
        public AccountController(IServiceBase<Account> serv) : base(serv) { }
    }
}