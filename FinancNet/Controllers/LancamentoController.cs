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

        [HttpGet()]
        public override IActionResult Get()
        {
            string dini = HttpContext.Request.Query["dini"].ToString();
            string dfin = HttpContext.Request.Query["dfin"].ToString();
            return Ok(serv.FindByPeriodo(dini, dfin));
        }
    }
}