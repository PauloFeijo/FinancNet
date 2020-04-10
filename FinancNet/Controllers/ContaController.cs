using FinancNet.Models;
using FinancNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private IContaService serv;

        public ContaController(IContaService serv)
        {
            this.serv = serv;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(serv.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var conta = serv.FindById(id);

            if (conta == null) return NotFound();

            return Ok(conta);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Conta conta)
        {
            if (conta == null) return BadRequest();

            return new ObjectResult(serv.Create(conta));
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Conta conta, int id)
        {
            if (conta == null) return BadRequest();

            conta.id = id;

            return new ObjectResult(serv.Update(conta));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            serv.Delete(id);

            return NoContent();
        }
    }
}