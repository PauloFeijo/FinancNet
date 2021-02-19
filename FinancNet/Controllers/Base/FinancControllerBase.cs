using FinancNet.Models;
using FinancNet.Models.Base;
using FinancNet.Services.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class FinancControllerBase<T> : ControllerBase where T : EntityBase
    {
        private IServiceBase<T> serv;

        public FinancControllerBase(IServiceBase<T> serv)
        {
            this.serv = serv;
        }

        private void AtualizarUsuarioLogado() => Usuario.Logado = User.Identity.Name;

        [HttpGet]
        public virtual IActionResult Get()
        {
            AtualizarUsuarioLogado();
            return Ok(serv.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            AtualizarUsuarioLogado();

            var item = serv.FindById(id);

            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody]T item)
        {
            AtualizarUsuarioLogado();

            if (item == null) return BadRequest();

            return new ObjectResult(serv.Create(item));
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] T item, int id)
        {
            AtualizarUsuarioLogado();

            if (item == null) return BadRequest();

            item.Id = id;

            return new ObjectResult(serv.Update(item));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AtualizarUsuarioLogado();

            serv.Delete(id);

            return NoContent();
        }
    }
}