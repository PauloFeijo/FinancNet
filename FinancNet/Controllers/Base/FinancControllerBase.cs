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
        private IServiceBase<T> _serv;

        public FinancControllerBase(IServiceBase<T> serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(_serv.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var item = _serv.FindById(id);

            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody]T item)
        {
            if (item == null) return BadRequest();

            return new ObjectResult(_serv.Create(item));
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] T item, int id)
        {
            if (item == null) return BadRequest();

            item.Id = id;

            return new ObjectResult(_serv.Update(item));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _serv.Delete(id);

            return NoContent();
        }
    }
}