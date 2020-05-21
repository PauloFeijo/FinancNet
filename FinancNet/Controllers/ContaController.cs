using FinancNet.Models;
using FinancNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContaController : Controller<Conta>
    {
        public ContaController(IService<Conta> serv) : base(serv) { }
    }
}