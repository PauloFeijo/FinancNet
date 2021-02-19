using FinancNet.Models;
using FinancNet.Services.Base;

namespace FinancNet.Controllers
{
    public class CategoriaController : FinancControllerBase<Categoria>
    {
        public CategoriaController(IServiceBase<Categoria> serv) : base(serv) { }
    }
}