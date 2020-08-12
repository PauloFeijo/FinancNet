using FinancNet.Models;
using FinancNet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService serv;

        public UsuarioController(IUsuarioService serv)
        {
            this.serv = serv;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody]Usuario usuario)
        {
            if (usuario == null) return BadRequest();

            return new ObjectResult(serv.Create(usuario));
        }
    }
}