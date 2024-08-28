using FinancNet.Entities;
using FinancNet.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService serv;

        public UserController(IUserService serv)
        {
            this.serv = serv;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null) return BadRequest();

            return new ObjectResult(serv.Create(user));
        }
    }
}