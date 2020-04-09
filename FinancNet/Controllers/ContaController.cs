using FinancNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("get contas");
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok("get conta");
        }

        [HttpPost]
        public IActionResult Post([FromBody]Conta conta)
        {
            return Ok("post conta");
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Conta conta)
        {
            return Ok("put conta");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}