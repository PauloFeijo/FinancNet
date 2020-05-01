using FinancNet.Models;
using FinancNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancNet.Controllers 
{
    [Route ("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase {
        private IService<Categoria> serv;

        public CategoriaController(IService<Categoria> serv) {
            this.serv = serv;
        }

        [HttpGet]
        public IActionResult Get () {
            return Ok (serv.FindAll ());
        }

        [HttpGet ("{id}")]
        public IActionResult Get (long id) {
            var categoria = serv.FindById (id);

            if (categoria == null) return NotFound ();

            return Ok (categoria);
        }

        [HttpPost]
        public IActionResult Post ([FromBody] Categoria categoria) {
            if (categoria == null) return BadRequest ();

            return new ObjectResult (serv.Create (categoria));
        }

        [HttpPut ("{id}")]
        public IActionResult Put ([FromBody] Categoria categoria, int id) {
            if (categoria == null) return BadRequest ();

            categoria.id = id;

            return new ObjectResult (serv.Update (categoria));
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete (int id) {
            serv.Delete (id);

            return NoContent ();
        }
    }
}