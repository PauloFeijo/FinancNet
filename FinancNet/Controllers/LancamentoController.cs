using FinancNet.Models;
using FinancNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LancamentoController : Controller<Lancamento>
    {
        private ILancamentoService serv;

        public LancamentoController(ILancamentoService serv) : base(serv)
        {
            this.serv = serv;
        }
    }
}