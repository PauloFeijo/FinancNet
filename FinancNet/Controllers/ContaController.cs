using FinancNet.Models;
using FinancNet.Services;

namespace FinancNet.Controllers
{
    public class ContaController : Controller<Conta>
    {
        public ContaController(IService<Conta> serv) : base(serv) { }
    }
}