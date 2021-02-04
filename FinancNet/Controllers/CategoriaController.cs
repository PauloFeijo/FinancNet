using FinancNet.Models;
using FinancNet.Services;

namespace FinancNet.Controllers
{
    public class CategoriaController : Controller<Categoria>
    {
        public CategoriaController(IService<Categoria> serv) : base(serv) { }
    }
}