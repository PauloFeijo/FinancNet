using FinancNet.Entities;
using FinancNet.Interfaces.Services.Base;

namespace FinancNet.Controllers
{
    public class CategoryController : FinancControllerBase<Category>
    {
        public CategoryController(IServiceBase<Category> serv) : base(serv) { }
    }
}