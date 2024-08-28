using FinancNet.Entities;
using FinancNet.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    public class TransferController : FinancControllerBase<Transfer>
    {
        private ITransferService serv;

        public TransferController(ITransferService serv) : base(serv)
        {
            this.serv = serv;
        }

        [HttpGet()]
        public override IActionResult Get()
        {
            string dini = HttpContext.Request.Query["dini"].ToString();
            string dfin = HttpContext.Request.Query["dfin"].ToString();
            return Ok(serv.FindByPeriod(dini, dfin));
        }
    }
}