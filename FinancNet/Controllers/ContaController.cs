using FinancNet.Models;
using FinancNet.Services;

namespace FinancNet.Controllers
{
    public class ContaController : FinancControllerBase<Conta>
    {
        public ContaController(IServiceBase<Conta> serv) : base(serv) { }
    }
}