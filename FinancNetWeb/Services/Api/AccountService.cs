using FinancNetWeb.Models.Dtos;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace FinancNetWeb.Services.Api
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        public ILogger<AccountService> _logger;
        private const string endpoint = "/account/";
        private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

        private AccountDto? account;
        private IEnumerable<AccountDto>? accounts;

        public AccountService(IHttpClientFactory httpClientFactory, ILogger<AccountService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("FinancNet");
            _logger = logger;
        }

        public async Task<AccountDto> Get(long id)
        {
            try
            {
                var response = await _httpClient.GetAsync(endpoint + id);

                if (response.IsSuccessStatusCode)
                {
                    account = await response.Content.ReadFromJsonAsync<AccountDto>();
                    return account;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro ao obter a carteira {id} - {message}");
                    throw new Exception($"Status Code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter a carteira {id} \n\n {ex.Message} ");
                throw new UnauthorizedAccessException();
            }
        }

        public async Task<List<AccountDto>> GetAll()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<AccountDto>>(endpoint);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao acessar carteiras: {endpoint} " + ex.Message);
                throw new UnauthorizedAccessException();
            }
        }

        public async Task<AccountDto> Create(AccountDto accountDto)
        {
            var content = new StringContent(JsonSerializer.Serialize(accountDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                account = await JsonSerializer.DeserializeAsync<AccountDto>(apiResponse, _jsonOptions);
                return account;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return null;
        }

        public async Task<AccountDto> Update(long id, AccountDto accountDto)
        {
            var response = await _httpClient.PutAsJsonAsync(endpoint + id, accountDto);

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                account = await JsonSerializer.DeserializeAsync<AccountDto>(apiResponse, _jsonOptions);
                return account;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return null;
        }

        public async Task<bool> Delete(long id)
        {
            var response = await _httpClient.DeleteAsync(endpoint + id);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            return false;
        }
    }
}
