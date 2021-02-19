using FinancNet.Models;
using FinancNet.Services;

namespace FinancNet.Controllers
{
    public class CategoriaController : FinancControllerBase<Categoria>
    {
        public CategoriaController(IServiceBase<Categoria> serv) : base(serv) { }
    }
}