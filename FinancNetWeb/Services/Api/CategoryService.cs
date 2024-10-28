using FinancNetWeb.Models.Dtos;
using FinancNetWeb.Services.Api.Base;

namespace FinancNetWeb.Services.Api
{
    public class CategoryService : ServiceBase<CategoryDto>, ICategoryService
    {
        public CategoryService(IHttpClientFactory httpClientFactory, ILogger<ServiceBase<CategoryDto>> logger) :
            base(httpClientFactory, logger, "/category/", "categoria")
        {
        }
    }
}
