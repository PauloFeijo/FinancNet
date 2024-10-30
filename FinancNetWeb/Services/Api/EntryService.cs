using FinancNetWeb.Models.Dtos;
using FinancNetWeb.Services.Api.Base;

namespace FinancNetWeb.Services.Api
{
    public class EntryService : ServiceBase<EntryDto>, IEntryService
    {
        public EntryService(IHttpClientFactory httpClientFactory, ILogger<ServiceBase<EntryDto>> logger) :
            base(httpClientFactory, logger, "/entry/", "lançamento")
        {
        }
    }
}
