using FinancNet.Models;
using FinancNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransferenciaController : Controller<Transferencia>
    {
        private ITransferenciaService serv;

        public TransferenciaController(ITransferenciaService serv) : base(serv)
        {
            this.serv = serv;
        }
    }
}