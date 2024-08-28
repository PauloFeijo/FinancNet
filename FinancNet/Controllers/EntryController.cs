using FinancNet.Entities;
using FinancNet.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    public class EntryController : FinancControllerBase<Entry>
    {
        private IEntryService serv;

        public EntryController(IEntryService serv) : base(serv)
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