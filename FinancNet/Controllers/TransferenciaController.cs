using FinancNet.Models;
using FinancNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    public class TransferenciaController : Controller<Transferencia>
    {
        private ITransferenciaService serv;

        public TransferenciaController(ITransferenciaService serv) : base(serv)
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