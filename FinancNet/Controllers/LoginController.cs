using FinancNet.Models;
using FinancNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioService serv;

        public LoginController(IUsuarioService serv)
        {
            this.serv = serv;
        }

        [HttpPost]
        public object Post([FromBody]Usuario usuario)
        {
            if (usuario == null) return BadRequest();

            return serv.FindByLogin(usuario);
        }
    }
}